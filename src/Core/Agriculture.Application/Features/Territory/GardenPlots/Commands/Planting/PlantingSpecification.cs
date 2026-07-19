using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Application.Features.Territory.GardenPlots.Commands.Planting
{
    public class PlantingSpecification
        : BaseSpecification<GardenPlot>
    {
        public Guid SpecicesId { get; set; }
        public PlantingSpecification(PlantingCommand command)
        {
            Criteria = gp => gp.PublicId == command.PlotId;

            SpecicesId = command.SpecicesId;

            AddIncludeAggregator(x => x.Include(gp => gp.Plant!)
                                        .ThenInclude((Plant p) => p.PlantSpecices)
                                        .ThenInclude((PlantSpecices ps) => ps.Category));
        }
    }
}
