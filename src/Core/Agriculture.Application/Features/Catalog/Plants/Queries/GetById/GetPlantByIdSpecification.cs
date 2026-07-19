using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Catalog.Plants.Queries.GetById
{
    public class GetPlantByIdSpecification
        : BaseSpecification<Plant>
    {
        public GetPlantByIdSpecification(GetPlantByIdQuery query)
        {
            Criteria = p => p.PublicId == query.Id;

            AddInclude(x => x.PlantSpecices);
            AddInclude(x => x.GardenPlot);

            EnableSoftDeleteFilter();
        }
    }
}
