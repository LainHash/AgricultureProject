using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services;
using Agriculture.Application.Services.Authentication;
using Agriculture.Contract.DTOs.Authentication;
using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Repositories.Identity;
using Agriculture.Persistence.Repositories.Identity;
using System.Net;

namespace Agriculture.Persistence.Services.Authentication
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public AuthenticationService(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork,
            IPasswordHasher passwordHasher,
            IJwtProvider jwtProvider,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
            _roleRepository = roleRepository;
        }

        public async Task<Result<AuthenticationResponse>> LoginAsync(
            LoginRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<object>> RegisterAsync(
            RegisterRequest request,
            CancellationToken cancellationToken = default)
        {
            var existingUser = await _userRepository.FindAsync(request.Email, cancellationToken);
            if (existingUser != null)
            {
                return Result<object>
                    .Fail("This email already used. Please user another email.", HttpStatusCode.Conflict);
            }

            var playerRole = await _roleRepository.FindAsync("Players", cancellationToken);
            if (playerRole is null)
            {
                return Result<object>
                    .Fail(Error<Role>.NotFound, HttpStatusCode.NotFound);
            }

            throw new NotImplementedException();
        }

        public Task<Result<object>> VerifyEmailAsync(
            Guid userId,
            VerifyEmailRequest request,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
