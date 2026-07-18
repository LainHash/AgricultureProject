using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Templates.GardenTemplates.GetById
{
    public class GetGardenTemplateByIdSpecification
        : BaseSpecification<GardenTemplate>
    {
        public GetGardenTemplateByIdSpecification(GetGardenTemplateByIdQuery query)
        {
            Criteria = t => t.PublicId == query.Id;

            AddInclude(x => x.GardenPlotTemplates);

            EnableSoftDeleteFilter();
        }
    }
}
