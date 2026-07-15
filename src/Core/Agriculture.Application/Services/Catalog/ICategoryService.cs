using Agriculture.Application.Features.Catalog.Categories.Queries;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Categories;

namespace Agriculture.Application.Services.Catalog
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<CategoryResponse>>> GetAllAsync(
            GetAllCategoriesSpecification specification,
            CancellationToken cancellationToken);
    }
}
