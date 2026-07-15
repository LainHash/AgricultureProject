using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using MediatR;

namespace Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetById
{
    internal class GetPlantSpecicesByIdQueryHandler
        : IRequestHandler<GetPlantSpecicesByIdQuery, Result<PlantSpecicesResponse>>
    {
        private readonly IPlantSpecicesService _plantSpecicesService;

        public GetPlantSpecicesByIdQueryHandler(IPlantSpecicesService plantSpecicesService)
        {
            _plantSpecicesService = plantSpecicesService;
        }

        public async Task<Result<PlantSpecicesResponse>> Handle(GetPlantSpecicesByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetPlantSpecicesByIdSpecification(request);
            var response = await _plantSpecicesService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
