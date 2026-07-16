using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Identity.Roles;
using MediatR;

namespace Agriculture.Application.Features.Identity.Roles.Queries.GetById
{
    public record GetRoleByIdQuery(Guid Id)
        : IRequest<Result<RoleResponse>>
    {
    }
}
