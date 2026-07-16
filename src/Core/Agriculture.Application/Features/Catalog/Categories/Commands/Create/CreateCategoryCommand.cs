using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Categories.Commands.Create
{
    public record CreateCategoryCommand(CreateCategoryRequest Body)
        : IRequest<Result<CategoryResponse>>
    {
    }
}
