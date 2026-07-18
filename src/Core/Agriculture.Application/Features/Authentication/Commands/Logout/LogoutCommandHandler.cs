using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Authentication;
using MediatR;

namespace Agriculture.Application.Features.Authentication.Commands.Logout
{
    internal class LogoutCommandHandler
        : IRequestHandler<LogoutCommand, Result<object>>
    {
        private readonly IAuthenticationService _authenticationService;

        public LogoutCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result<object>> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.LogoutAsync(request.PublicUserId, cancellationToken);
        }
    }
}
