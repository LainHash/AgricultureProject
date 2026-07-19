using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.Plants;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Plants.Queries.GetAll
{
    internal class GetAllPlantsQueryHandler
        : IRequestHandler<GetAllPlantsQuery, Result<IEnumerable<PlantResponse>>>
    {
        private readonly IPlantService _plantService;

        public GetAllPlantsQueryHandler(IPlantService plantService)
        {
            _plantService = plantService;
        }

        public async Task<Result<IEnumerable<PlantResponse>>> Handle(GetAllPlantsQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllPlantsSpecification(request);
            var response = await _plantService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
