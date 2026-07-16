using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Categories.Commands.Delete
{
    internal class DeleteCategoryCommandHandler
        : IRequestHandler<DeleteCategoryCommand, Result<object>>
    {
        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<object>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var specification = new DeleteCategorySpecification(request);
            var response = await _categoryService.DeleteAsync(specification, cancellationToken);
            return response;
        }
    }
}
