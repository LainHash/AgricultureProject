using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Territory.GardenPlots;
using Agriculture.Contract.DTOs.Territory.Gardens;
using MediatR;

namespace Agriculture.Application.Features.Territory.Gardens.Commands.AddPlot
{
    public record AddGardenPlotsCommand(Guid GardenId, IEnumerable<AddGardenPlotRequest> Body)
        : IRequest<Result<GardenResponse>>
    {
    }
}
