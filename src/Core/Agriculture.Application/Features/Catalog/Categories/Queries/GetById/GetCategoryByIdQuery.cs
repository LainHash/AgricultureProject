using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Categories.Queries.GetById
{
    public record GetCategoryByIdQuery(Guid Id)
        : IRequest<Result<CategoryResponse>>
    {
    }
}
