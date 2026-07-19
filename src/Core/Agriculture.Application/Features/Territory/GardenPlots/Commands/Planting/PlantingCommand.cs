using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Territory.GardenPlots;
using MediatR;

namespace Agriculture.Application.Features.Territory.GardenPlots.Commands.Planting
{
    public record PlantingCommand(Guid PlotId, Guid SpecicesId)
        : IRequest<Result<GardenPlotResponse>>
    {
    }
}
