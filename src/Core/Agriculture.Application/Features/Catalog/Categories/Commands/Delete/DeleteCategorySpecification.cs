using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Catalog.Categories.Commands.Delete
{
    public class DeleteCategorySpecification
        : BaseSpecification<Category>
    {
        public DeleteCategorySpecification(DeleteCategoryCommand command)
        {
            Criteria = c => c.PublicId == command.Id;
        }
    }
}
