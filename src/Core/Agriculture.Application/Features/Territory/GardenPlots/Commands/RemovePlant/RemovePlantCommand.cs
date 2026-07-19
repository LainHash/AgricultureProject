using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Territory.GardenPlots;
using MediatR;

namespace Agriculture.Application.Features.Territory.GardenPlots.Commands.RemovePlant
{
    public record RemovePlantCommand(Guid Id)
        : IRequest<Result<GardenPlotResponse>>
    {
    }
}
