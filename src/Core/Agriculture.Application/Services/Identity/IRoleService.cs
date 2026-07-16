using Agriculture.Application.Features.Identity.Roles.Queries.GetAll;
using Agriculture.Application.Features.Identity.Roles.Queries.GetById;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Identity.Roles;

namespace Agriculture.Application.Services.Identity
{
    public interface IRoleService
    {
        Task<Result<IEnumerable<RoleResponse>>> GetAllAsync(
            GetAllRoleSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<RoleResponse>> GetByIdAsync(
            GetRoleByIdSpecification specification,
            CancellationToken cancellationToken);
    }
}
