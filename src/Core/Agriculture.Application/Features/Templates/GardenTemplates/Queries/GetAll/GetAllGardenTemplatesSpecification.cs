using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Templates.GardenTemplates.Queries.GetAll
{
    public class GetAllGardenTemplatesSpecification
        : BaseSpecification<GardenTemplate>
    {
        public GetAllGardenTemplatesSpecification(GetAllGardenTemplatesQuery query)
        {
            AddInclude(x => x.GardenPlotTemplates);

            EnableSoftDeleteFilter();
        }
    }
}
