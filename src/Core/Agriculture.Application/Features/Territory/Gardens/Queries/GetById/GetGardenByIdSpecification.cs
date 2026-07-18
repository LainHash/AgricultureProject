using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Specifications;
using MediatR;

namespace Agriculture.Application.Features.Territory.Gardens.Queries.GetById
{
    public class GetGardenByIdSpecification
        : BaseSpecification<Garden>
    {
        public GetGardenByIdSpecification(GetGardenByIdQuery query)
        {
            Criteria = g => g.PublicId == query.Id;

            AddInclude(x => x.GardenPlots);

            EnableSoftDeleteFilter();
        }
    }
}
