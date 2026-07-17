using Agriculture.Contract.DTOs.Territory;
using Agriculture.Domain.Entites.Territory;
using AutoMapper;

namespace Agriculture.Persistence.Mapping.Territory
{
    public class GardenMapping : Profile
    {
        public GardenMapping()
        {
            CreateMap<Garden, GardenResponse>();
        }
    }
}
