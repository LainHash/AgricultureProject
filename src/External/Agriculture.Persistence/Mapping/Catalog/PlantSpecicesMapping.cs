using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using Agriculture.Domain.Entites.Catalog;
using AutoMapper;
using static Agriculture.Persistence.Seeders.Catalog.PlantSpecicesSeeder;

namespace Agriculture.Persistence.Mapping.Catalog
{
    internal class PlantSpecicesMapping : Profile
    {
        public PlantSpecicesMapping()
        {
            CreateMap<PlantSpecices, PlantSpecicesResponse>();
            CreateMap<CreatePlantSpecicesRequest, PlantSpecices>();
            CreateMap<PlantSpecicesRecord, PlantSpecices>();
        }
    }
}
