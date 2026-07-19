using Agriculture.Contract.DTOs.Catalog.Plants;
using Agriculture.Domain.Entites.Catalog;
using AutoMapper;

namespace Agriculture.Persistence.Mapping.Catalog
{
    internal class PlantMapping : Profile
    {
        public PlantMapping()
        {
            CreateMap<Plant, PLantResponse>();
        }
    }
}
