using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using Agriculture.Domain.Entites.Catalog;
using AutoMapper;

namespace Agriculture.Persistence.Mapping.Catalog
{
    internal class PlantSpecicesMapping : Profile
    {
        public PlantSpecicesMapping()
        {
            CreateMap<PlantSpecices, PlantSpecicesResponse>();
            CreateMap<CreatePlantSpecicesRequest, PlantSpecices>();
        }
    }
}
