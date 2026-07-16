using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetById
{
    public class GetPlantSpecicesByIdSpecification
        : BaseSpecification<PlantSpecices>
    {
        public GetPlantSpecicesByIdSpecification(GetPlantSpecicesByIdQuery query)
        {
            Criteria = ps => ps.PublicId == query.Id;

            EnableSoftDeleteFilter();
        }
    }
}
