using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Territory.Gardens.GetAll
{
    public class GetAllGardensSpecification
        : BaseSpecification<Garden>
    {
        public GetAllGardensSpecification(GetAllGardensQuery query)
        {
            AddInclude(x => x.GardenPlots);

            EnableSoftDeleteFilter();
        }
    }
}
