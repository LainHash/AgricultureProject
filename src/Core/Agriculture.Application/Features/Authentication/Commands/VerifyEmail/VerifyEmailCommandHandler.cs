using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Authentication;
using MediatR;

namespace Agriculture.Application.Features.Authentication.Commands.VerifyEmail
{
    internal class VerifyEmailCommandHandler
        : IRequestHandler<VerifyEmailCommand, Result<object>>
    {
        private readonly IAuthenticationService _authenticationService;

        public VerifyEmailCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<object>> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.VerifyEmailAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
