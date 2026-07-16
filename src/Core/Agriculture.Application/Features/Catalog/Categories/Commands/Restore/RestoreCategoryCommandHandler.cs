using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Categories.Commands.Restore
{
    internal class RestoreCategoryCommandHandler
        : IRequestHandler<RestoreCategoryCommand, Result<object>>
    {
        private readonly ICategoryService _categoryService;

        public RestoreCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Result<object>> Handle(RestoreCategoryCommand request, CancellationToken cancellationToken)
        {
            var specification = new RestoreCategorySpecification(request);
            var response = await _categoryService.RestoreAsync(specification, cancellationToken);
            return response;
        }
    }
}
