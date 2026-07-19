using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Territory;
using Agriculture.Contract.DTOs.Territory.GardenPlots;
using MediatR;

namespace Agriculture.Application.Features.Territory.GardenPlots.Commands.Planting
{
    internal class PlantingCommandHandler
        : IRequestHandler<PlantingCommand, Result<GardenPlotResponse>>
    {
        private readonly IGardenPlotService _gardenPlotService;

        public PlantingCommandHandler(IGardenPlotService gardenPlotService)
        {
            _gardenPlotService = gardenPlotService;
        }

        public async Task<Result<GardenPlotResponse>> Handle(PlantingCommand request, CancellationToken cancellationToken)
        {
            var specification = new PlantingSpecification(request);
            var response = await _gardenPlotService.PlantAsync(specification, cancellationToken);
            return response;
        }
    }
}
