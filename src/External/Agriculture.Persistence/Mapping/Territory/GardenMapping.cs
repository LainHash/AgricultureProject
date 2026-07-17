using Agriculture.Contract.DTOs.Territory;
using Agriculture.Domain.Entites.Territory;
using AutoMapper;
using static Agriculture.Persistence.Seeders.Territory.GardenPlotSeeder;
using static Agriculture.Persistence.Seeders.Territory.GardenSeeder;

namespace Agriculture.Persistence.Mapping.Territory
{
    public class GardenMapping : Profile
    {
        public GardenMapping()
        {
            CreateMap<Garden, GardenResponse>();
            CreateMap<GardenPlot, GardenPlotResponse>();
            CreateMap<GardenRecord, Garden>();
            CreateMap<GardenPlotRecord, GardenPlot>();
        }
    }
}
