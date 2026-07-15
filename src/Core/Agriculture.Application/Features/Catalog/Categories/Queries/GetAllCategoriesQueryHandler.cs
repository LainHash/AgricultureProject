using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Categories.Queries
{
    internal class GetAllCategoriesQueryHandler
        : IRequestHandler<GetAllCategoriesQuery, Result<IEnumerable<CategoryResponse>>>
    {
        private readonly ICategoryService _categoryService;

        public GetAllCategoriesQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<IEnumerable<CategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllCategoriesSpecification(request);
            var response = await _categoryService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
