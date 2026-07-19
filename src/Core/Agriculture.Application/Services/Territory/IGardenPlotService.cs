using Agriculture.Application.Features.Territory.GardenPlots.Commands.Planting;
using Agriculture.Application.Features.Territory.GardenPlots.Commands.RemovePlant;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Territory.GardenPlots;

namespace Agriculture.Application.Services.Territory
{
    public interface IGardenPlotService
    {
        Task<Result<GardenPlotResponse>> PlantAsync(
            PlantingSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<GardenPlotResponse>> RemovePlantAsync(
            RemovePlantSpecification specification,
            CancellationToken cancellationToken);
    }
}
