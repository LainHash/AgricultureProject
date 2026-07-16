using Agriculture.Contract.DTOs.Identity.Roles;
using Agriculture.Domain.Entites.Identity;
using AutoMapper;

namespace Agriculture.Persistence.Mapping.Identity
{
    internal class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<CreateRoleRequest, Role>();
            CreateMap<Role, RoleResponse>();
        }
    }
}
