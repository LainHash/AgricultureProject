using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using MediatR;

namespace Agriculture.Application.Features.Catalog.PlantSpecicess.Commands.Create
{
    internal class CreatePlantSpecicesCommandHandler
        : IRequestHandler<CreatePlantSpecicesCommand, Result<PlantSpecicesResponse>>
    {
        private readonly IPlantSpecicesService _plantSpecicesService;

        public CreatePlantSpecicesCommandHandler(IPlantSpecicesService plantSpecicesService)
        {
            _plantSpecicesService = plantSpecicesService;
        }

        public async Task<Result<PlantSpecicesResponse>> Handle(CreatePlantSpecicesCommand request, CancellationToken cancellationToken)
        {
            var specification = new CreatePlantSpecicesSpecification(request);
            var response = await _plantSpecicesService.CreateAsync(specification, cancellationToken);
            return response;
        }
    }
}
