using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Plants;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Plants.Commands.Planting
{
    public record PlantCommand(PlantRequest Body)
        : IRequest<Result<PlantResponse>>
    {
    }
}
