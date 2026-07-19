using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.Plants;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Plants.Commands.Planting
{
    internal class PlantCommandHandler
        : IRequestHandler<PlantCommand, Result<PlantResponse>>
    {
        private readonly IPlantService _plantService;

        public PlantCommandHandler(IPlantService plantService)
        {
            _plantService = plantService;
        }

        public async Task<Result<PlantResponse>> Handle(PlantCommand request, CancellationToken cancellationToken)
        {
            var specification = new PlantSpecification(request);
            var response = await _plantService.PlantAsync(specification, cancellationToken);
            return response;
        }
    }
}
