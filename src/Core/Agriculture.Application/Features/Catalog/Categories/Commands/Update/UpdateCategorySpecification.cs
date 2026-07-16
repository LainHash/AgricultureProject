using Agriculture.Contract.DTOs.Catalog.Categories;
using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Catalog.Categories.Commands.Update
{
    public class UpdateCategorySpecification
        : BaseSpecification<Category>
    {
        public UpdateCategoryRequest Body { get; set; }
        public UpdateCategorySpecification(UpdateCategoryCommand command)
        {
            Criteria = c => c.PublicId == command.Id;
            Body = command.Body;
        }
    }
}
