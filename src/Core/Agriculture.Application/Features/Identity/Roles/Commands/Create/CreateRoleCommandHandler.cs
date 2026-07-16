using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Identity;
using Agriculture.Contract.DTOs.Identity.Roles;
using MediatR;

namespace Agriculture.Application.Features.Identity.Roles.Commands.Create
{
    internal class CreateRoleCommandHandler
        : IRequestHandler<CreateRoleCommand, Result<RoleResponse>>
    {
        private readonly IRoleService _roleService;

        public CreateRoleCommandHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<Result<RoleResponse>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = await _roleService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
