using Agriculture.Contract.DTOs.Territory.GardenPlots;
using Agriculture.Contract.DTOs.Territory.Gardens;
using Agriculture.Domain.Entites.Territory;
using AutoMapper;

namespace Agriculture.Persistence.Mapping.Territory
{
    public class GardenMapping : Profile
    {
        public GardenMapping()
        {
            CreateMap<Garden, GardenResponse>();
            CreateMap<GardenPlot, GardenPlotResponse>();

            CreateMap<AddGardenPlotRequest, GardenPlot>();
        }
    }
}
