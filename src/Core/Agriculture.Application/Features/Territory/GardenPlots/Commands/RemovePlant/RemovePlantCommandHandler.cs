using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Territory;
using Agriculture.Contract.DTOs.Territory.GardenPlots;
using MediatR;

namespace Agriculture.Application.Features.Territory.GardenPlots.Commands.RemovePlant
{
    internal class RemovePlantCommandHandler
        : IRequestHandler<RemovePlantCommand, Result<GardenPlotResponse>>
    {
        private readonly IGardenPlotService _gardenPlotService;

        public RemovePlantCommandHandler(IGardenPlotService gardenPlotService)
        {
            _gardenPlotService = gardenPlotService;
        }

        public async Task<Result<GardenPlotResponse>> Handle(RemovePlantCommand request, CancellationToken cancellationToken)
        {
            var specification = new RemovePlantSpecification(request);
            var response = await _gardenPlotService.RemovePlantAsync(specification, cancellationToken);
            return response;
        }
    }
}
