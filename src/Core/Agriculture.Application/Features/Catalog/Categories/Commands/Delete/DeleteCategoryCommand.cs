using Agriculture.Application.Models.Results;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Categories.Commands.Delete
{
    public record DeleteCategoryCommand(Guid Id)
        : IRequest<Result<object>>
    {
    }
}
