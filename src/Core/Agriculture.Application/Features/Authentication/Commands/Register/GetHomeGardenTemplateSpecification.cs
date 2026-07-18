using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Authentication.Commands.Register
{
    public class GetHomeGardenTemplateSpecification
        : BaseSpecification<GardenTemplate>
    {
        public GetHomeGardenTemplateSpecification()
        {
            Criteria = hg => hg.Name == "Home Garden";
            AddInclude(x => x.GardenPlotTemplates);
        }
    }
}
