using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.Plants;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Plants.Queries.GetById
{
    internal class GetPlantByIdQueryHandler
        : IRequestHandler<GetPlantByIdQuery, Result<PlantResponse>>
    {
        private readonly IPlantService _plantService;

        public GetPlantByIdQueryHandler(IPlantService plantService)
        {
            _plantService = plantService;
        }

        public async Task<Result<PlantResponse>> Handle(GetPlantByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetPlantByIdSpecification(request);
            var response = await _plantService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
