using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Identity.Roles;
using MediatR;

namespace Agriculture.Application.Features.Identity.Roles.Commands.Create
{
    public record CreateRoleCommand(CreateRoleRequest Body)
        : IRequest<Result<RoleResponse>>
    {
    }
}
