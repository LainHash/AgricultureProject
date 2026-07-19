using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Catalog.Plants.Queries.GetAll
{
    public class GetAllPlantsSpecification
        : BaseSpecification<Plant>
    {
        public GetAllPlantsSpecification(GetAllPlantsQuery query)
        {
            AddInclude(x => x.PlantSpecices);
            AddInclude(x => x.GardenPlot);

            EnableSoftDeleteFilter();
        }
    }
}
