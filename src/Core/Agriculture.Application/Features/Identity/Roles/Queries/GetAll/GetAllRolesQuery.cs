using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Identity.Roles;
using MediatR;

namespace Agriculture.Application.Features.Identity.Roles.Queries.GetAll
{
    public record GetAllRolesQuery
        : IRequest<Result<IEnumerable<RoleResponse>>>
    {
    }
}
