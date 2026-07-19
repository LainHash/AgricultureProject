using Agriculture.Contract.DTOs.Identity.Roles;
using Agriculture.Domain.Entites.Identity;
using AutoMapper;
using static Agriculture.Persistence.Seeders.Identity.RoleSeeder;

namespace Agriculture.Persistence.Mapping.Identity
{
    internal class RoleMapping : Profile
    {
        public RoleMapping()
        {
            CreateMap<RoleRecord, Role>();
            CreateMap<CreateRoleRequest, Role>();
            CreateMap<Role, RoleResponse>();
        }
    }
}
