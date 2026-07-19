using Agriculture.Application.Features.Territory.GardenPlots.Commands.Planting;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Plants;

namespace Agriculture.Application.Services.Territory
{
    public interface IGardenPlotService
    {
        Task<Result<GardenPlotResponse>> PlantAsync(
            PlantingSpecification specification,
            CancellationToken cancellationToken);
    }
}
