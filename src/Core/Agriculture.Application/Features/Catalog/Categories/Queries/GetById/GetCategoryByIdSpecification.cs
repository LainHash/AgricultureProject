using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Catalog.Categories.Queries.GetById
{
    public class GetCategoryByIdSpecification
        : BaseSpecification<Category>
    {
        public GetCategoryByIdSpecification(GetCategoryByIdQuery query)
        {
            Criteria = c => c.PublicId == query.Id;

            EnableSoftDeleteFilter();
        }
    }
}
