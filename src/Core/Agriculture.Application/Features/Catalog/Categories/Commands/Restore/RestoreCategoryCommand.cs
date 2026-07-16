using Agriculture.Application.Models.Results;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Categories.Commands.Restore
{
    public record RestoreCategoryCommand(Guid Id)
        : IRequest<Result<object>>
    {
    }
}
