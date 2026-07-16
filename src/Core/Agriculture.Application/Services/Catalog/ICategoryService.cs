using Agriculture.Application.Features.Catalog.Categories.Commands.Delete;
using Agriculture.Application.Features.Catalog.Categories.Commands.Restore;
using Agriculture.Application.Features.Catalog.Categories.Commands.Update;
using Agriculture.Application.Features.Catalog.Categories.Queries.GetAll;
using Agriculture.Application.Features.Catalog.Categories.Queries.GetById;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Categories;

namespace Agriculture.Application.Services.Catalog
{
    public interface ICategoryService
    {
        Task<Result<IEnumerable<CategoryResponse>>> GetAllAsync(
            GetAllCategoriesSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<CategoryResponse>> GetByIdAsync(
            GetCategoryByIdSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<CategoryResponse>> CreateAsync(
            CreateCategoryRequest request,
            CancellationToken cancellationToken);

        Task<Result<CategoryResponse>> UpdateAsync(
            UpdateCategorySpecification specification,
            CancellationToken cancellationToken);

        Task<Result<object>> DeleteAsync(
            DeleteCategorySpecification specification,
            CancellationToken cancellationToken);

        Task<Result<object>> RestoreAsync(
            RestoreCategorySpecification specification,
            CancellationToken cancellationToken);
    }
}
