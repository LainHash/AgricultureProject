using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Application.Features.Catalog.Plants.Queries.GetById
{
    public class GetPlantByIdSpecification
        : BaseSpecification<Plant>
    {
        public GetPlantByIdSpecification(GetPlantByIdQuery query)
        {
            Criteria = p => p.PublicId == query.Id;

            AddIncludeAggregator(x => x.Include(p => p.PlantSpecices)
                                        .ThenInclude(ps => ps.Category));
            AddInclude(x => x.GardenPlot);

            EnableSoftDeleteFilter();
        }
    }
}
