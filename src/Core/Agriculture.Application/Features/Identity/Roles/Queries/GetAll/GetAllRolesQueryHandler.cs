using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Identity;
using Agriculture.Contract.DTOs.Identity.Roles;
using MediatR;

namespace Agriculture.Application.Features.Identity.Roles.Queries.GetAll
{
    internal class GetAllRolesQueryHandler
        : IRequestHandler<GetAllRolesQuery, Result<IEnumerable<RoleResponse>>>
    {
        private readonly IRoleService _roleService;

        public GetAllRolesQueryHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result<IEnumerable<RoleResponse>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllRolesSpecification(request);
            var response = await _roleService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
