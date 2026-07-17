using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Authentication;
using Agriculture.Contract.DTOs.Authentication;
using MediatR;

namespace Agriculture.Application.Features.Authentication.Commands.Login
{
    internal class LoginCommandHandler
        : IRequestHandler<LoginCommand, Result<AuthenticationResponse>>
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<AuthenticationResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.LoginAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
