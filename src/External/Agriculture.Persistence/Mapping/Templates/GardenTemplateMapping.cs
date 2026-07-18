using Agriculture.Contract.DTOs.Templates.GardenPlotTemplates;
using Agriculture.Contract.DTOs.Templates.GardenTemplates;
using Agriculture.Domain.Entites.Templates;
using AutoMapper;
using static Agriculture.Persistence.Seeders.Templates.GardenPlotTemplateSeeder;
using static Agriculture.Persistence.Seeders.Templates.GardenTemplateSeeder;

namespace Agriculture.Persistence.Mapping.Templates
{
    internal class GardenTemplateMapping : Profile
    {
        public GardenTemplateMapping()
        {
            CreateMap<GardenTemplateRecord, GardenTemplate>();
            CreateMap<GardenPlotTemplateRecord, GardenPlotTemplate>();

            CreateMap<GardenTemplate, GardenTemplateResponse>();
            CreateMap<GardenPlotTemplate, GardenPlotTemplateResponse>();
        }
    }
}
