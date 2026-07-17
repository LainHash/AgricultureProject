using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Authentication;
using MediatR;

namespace Agriculture.Application.Features.Authentication.Commands.ResendVerification
{
    internal class ResendVerificationCommandHandler
        : IRequestHandler<ResendVerificationCommand, Result<object>>
    {
        private readonly IAuthenticationService _authenticationService;

        public ResendVerificationCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<object>> Handle(
            ResendVerificationCommand request,
            CancellationToken cancellationToken)
        {
            return await _authenticationService.ResendVerificationAsync(request.Body, cancellationToken);
        }
    }
}
