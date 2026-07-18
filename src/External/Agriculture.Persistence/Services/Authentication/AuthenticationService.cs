using Agriculture.Application.Features.Authentication.Commands.Register;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services;
using Agriculture.Application.Services.Authentication;
using Agriculture.Application.Services.Emails;
using Agriculture.Application.Services.Guest;
using Agriculture.Contract.DTOs.Authentication;
using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Enums;
using Agriculture.Domain.Repositories.Guest;
using Agriculture.Domain.Repositories.Identity;
using Agriculture.Domain.Repositories.Templates;
using Agriculture.Domain.Repositories.Territory;
using Agriculture.Domain.Specifications;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Security.Cryptography;

namespace Agriculture.Persistence.Services.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenticationService> _logger;
        private readonly IPlayerService _playerService;

        public AuthenticationService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider,
            IRoleRepository roleRepository,
            IMapper mapper,
            IEmailService emailService,
            ILogger<AuthenticationService> logger,
            IPlayerService playerService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
            _roleRepository = roleRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
            _playerService = playerService;
        }

        public async Task<Result<object>> RegisterAsync(
            RegisterRequest request,
            CancellationToken cancellationToken = default)
        {
            await using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                var existingUser = await _userRepository.FindAsync(request.Email, cancellationToken);
                if (existingUser != null)
                {
                    return Result<object>
                        .Fail("This email already used. Please use another email.", HttpStatusCode.Conflict);
                }

                var playerRole = await _roleRepository.FindAsync(nameof(RoleNames.Player), cancellationToken);
                if (playerRole is null)
                {
                    return Result<object>
                        .Fail(Error<Role>.NotFound, HttpStatusCode.InternalServerError);
                }

                var user = _mapper.Map<User>(request);

                user.SetRole(playerRole.Id);
                user.SetPassword(_passwordHasher.HashPassword(request.Password));

                var verificationCode = GenerateCode();
                user.SetVerificationCode(verificationCode);

                _userRepository.Add(user);

                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _playerService.InitializeAsync(user.Id, cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                try
                {
                    var message = new EmailMessage(user.Username, verificationCode);
                    await _emailService.SendEmailAsync(user.Email, message, cancellationToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Send verification email failed.");
                }

                return Result<object>
                .Succeed(default, "Register successfully. Please check email later.", HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);

                _logger.LogError(ex, "Register request failed. Email: {Email}", request.Email);
                return Result<object>
                    .Fail("Register request failed.", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Result<object>> VerifyEmailAsync(
            VerifyEmailRequest request,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(request.Email, cancellationToken);
            if (user == null)
            {
                return Result<object>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            if (user.IsActive)
            {
                return Result<object>
                    .Fail("Account is already active.", HttpStatusCode.Conflict);
            }

            if (user.VerificationCode != request.Code)
            {
                return Result<object>
                    .Fail("Invalid verification code.", HttpStatusCode.Conflict);
            }

            if (user.VerificationCodeExpiresAt < DateTime.UtcNow)
            {
                return Result<object>
                    .Fail("Verification code has expired. Please request a new one.", HttpStatusCode.RequestTimeout);
            }

            user.CompleteVerification();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, "Email verified successfully. You can now login.", HttpStatusCode.Accepted);
        }

        public async Task<Result<AuthenticationResponse>> LoginAsync(
            LoginRequest request,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(request.Email, cancellationToken);
            if (user is null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            {
                return Result<AuthenticationResponse>
                    .Fail("Incorrect email or password.", HttpStatusCode.Unauthorized);
            }

            if (!user.IsActive)
            {
                return Result<AuthenticationResponse>
                    .Fail("Account is not active. Please verify your email.", HttpStatusCode.PreconditionRequired);
            }

            var role = await _roleRepository.FindAsync(user.RoleId, cancellationToken);
            var roleName = role?.Name ?? "Player";

            var token = _jwtProvider.GenerateToken(user.PublicId, user.Username, user.Email, roleName);

            var response = new AuthenticationResponse
            {
                UserId = user.PublicId,
                UserName = user.Username,
                Email = user.Email,
                Token = token
            };

            await _playerService.LoginAsync(user.Id, cancellationToken);

            return Result<AuthenticationResponse>
                .Succeed(response, "Login successfully.", HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> ResendVerificationAsync(
            ResendVerificationRequest request,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(request.Email, cancellationToken);
            if (user is null)
            {
                return Result<object>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            if (user.IsActive)
            {
                return Result<object>
                    .Fail("Account is already active.", HttpStatusCode.Conflict);
            }

            var newCode = GenerateCode();
            user.SetVerificationCode(newCode);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            try
            {
                var message = new EmailMessage(user.Username, newCode);
                await _emailService.SendEmailAsync(user.Email, message, cancellationToken);

                return Result<object>
                .Succeed(default, "Verification email resent. Please check your inbox.", HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Resend verification email failed. Email: {Email}", user.Email);
                throw;
            }
        }

        public async Task<Result<object>> LogoutAsync(
            Guid publicUserId,
            CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(publicUserId, cancellationToken);
            if (user is null)
            {
                return Result<object>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            await _playerService.LogoutAsync(user.Id, cancellationToken);

            return Result<object>
                .Succeed(default, "Logout successfully.", HttpStatusCode.OK);
        }

        private string GenerateCode()
        {
            return RandomNumberGenerator.GetInt32(100000, 1000000).ToString();
        }
    }
}
