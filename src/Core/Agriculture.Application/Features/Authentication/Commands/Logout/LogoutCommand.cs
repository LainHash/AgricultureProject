using Agriculture.Application.Models.Results;
using MediatR;

namespace Agriculture.Application.Features.Authentication.Commands.Logout
{
    public record LogoutCommand(Guid PublicUserId)
        : IRequest<Result<object>>
    {
    }
}
