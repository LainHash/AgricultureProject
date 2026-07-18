using Agriculture.Application.Features.Authentication.Commands.Register;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Authentication;

namespace Agriculture.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<Result<object>> RegisterAsync(
            RegisterRequest request,
            GetHomeGardenTemplateSpecification getHomeGardenTemplateSpecification,
            CancellationToken cancellationToken = default);

        Task<Result<AuthenticationResponse>> LoginAsync(
            LoginRequest request,
            CancellationToken cancellationToken = default);

        Task<Result<object>> VerifyEmailAsync(
            VerifyEmailRequest request,
            CancellationToken cancellationToken = default);

        Task<Result<object>> ResendVerificationAsync(
            ResendVerificationRequest request,
            CancellationToken cancellationToken = default);
    }
}
