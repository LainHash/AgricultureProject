using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Categories.Queries.GetAll
{
    public record GetAllCategoriesQuery
        : IRequest<Result<IEnumerable<CategoryResponse>>>
    {
    }
}
