using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Authentication;
using MediatR;

namespace Agriculture.Application.Features.Authentication.Commands.Login
{
    public record LoginCommand(LoginRequest Body)
        : IRequest<Result<AuthenticationResponse>>
    {
    }
}
