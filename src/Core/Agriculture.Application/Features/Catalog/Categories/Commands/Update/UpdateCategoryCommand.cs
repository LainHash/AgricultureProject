using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Categories;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Categories.Commands.Update
{
    public record UpdateCategoryCommand(Guid Id, UpdateCategoryRequest Body)
        : IRequest<Result<CategoryResponse>>
    {
    }
}
