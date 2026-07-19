using Agriculture.Contract.DTOs.Catalog.Plants;
using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Agriculture.Application.Features.Catalog.Plants.Commands.Planting
{
    public class PlantSpecification
        : BaseSpecification<Plant>
    {
        public PlantRequest Body { get; set; }
        public PlantSpecification(PlantCommand command)
        {
            Body = command.Body;

            AddIncludeAggregator(x => x.Include(p => p.PlantSpecices)
                                        .ThenInclude(ps => ps.Category));
            AddInclude(x => x.GardenPlot);
        }

        public void ApplyCriteria(int id)
        {
            Criteria = p => p.Id == id;
        }
    }
}
