using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using MediatR;

namespace Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetAll
{
    internal class GetAllPlantSpecicesQueryHandler
        : IRequestHandler<GetAllPlantSpecicesQuery, Result<IEnumerable<PlantSpecicesResponse>>>
    {
        private readonly IPlantSpecicesService _plantSpecicesService;

        public GetAllPlantSpecicesQueryHandler(IPlantSpecicesService plantSpecicesService)
        {
            _plantSpecicesService = plantSpecicesService;
        }

        public async Task<Result<IEnumerable<PlantSpecicesResponse>>> Handle(GetAllPlantSpecicesQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllPlantSpecicesSpecification(request);
            var response = await _plantSpecicesService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
