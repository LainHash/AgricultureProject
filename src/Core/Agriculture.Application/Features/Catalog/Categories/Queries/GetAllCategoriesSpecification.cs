using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Catalog.Categories.Queries
{
    public class GetAllCategoriesSpecification
        : BaseSpecification<Category>
    {
        public GetAllCategoriesSpecification(GetAllCategoriesQuery query) { }
    }
}
