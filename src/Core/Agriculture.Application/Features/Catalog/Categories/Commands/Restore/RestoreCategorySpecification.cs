using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Catalog.Categories.Commands.Restore
{
    public class RestoreCategorySpecification
        : BaseSpecification<Category>
    {
        public RestoreCategorySpecification(RestoreCategoryCommand command)
        {
            Criteria = c => c.PublicId == command.Id;
        }
    }
}
