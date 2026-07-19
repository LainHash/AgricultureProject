using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Application.Features.Catalog.Plants.Queries.GetAll
{
    public class GetAllPlantsSpecification
        : BaseSpecification<Plant>
    {
        public GetAllPlantsSpecification(GetAllPlantsQuery query)
        {
            AddIncludeAggregator(x => x.Include(p => p.PlantSpecices)
                                        .ThenInclude(ps => ps.Category));
            AddInclude(x => x.GardenPlot);

            EnableSoftDeleteFilter();
        }
    }
}
