using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetAll
{
    public class GetAllPlantSpecicesSpecification
        : BaseSpecification<PlantSpecices>
    {
        public GetAllPlantSpecicesSpecification(GetAllPlantSpecicesQuery query)
        {
            AddInclude(x => x.Category);

            EnableSoftDeleteFilter();
        }
    }
}
