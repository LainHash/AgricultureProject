using Agriculture.Contract.DTOs.Authentication;
using Agriculture.Domain.Entites.Identity;
using AutoMapper;

namespace Agriculture.Persistence.Mapping.Identity
{
    internal class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<RegisterRequest, User>();
        }
    }
}
