using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Categories.Commands.Create
{
    internal class CreateCategoryCommandHandler
        : IRequestHandler<CreateCategoryCommand, Result<CategoryResponse>>
    {
        private readonly ICategoryService _categoryService;

        public CreateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<CategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = await _categoryService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
