using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Territory;
using Agriculture.Contract.DTOs.Territory.Gardens;
using MediatR;

namespace Agriculture.Application.Features.Territory.Gardens.GetAll
{
    internal class GetAllGardensQueryHandler
        : IRequestHandler<GetAllGardensQuery, Result<IEnumerable<GardenResponse>>>
    {
        private readonly IGardenService _gardenService;

        public GetAllGardensQueryHandler(IGardenService gardenService)
        {
            _gardenService = gardenService;
        }

        public async Task<Result<IEnumerable<GardenResponse>>> Handle(GetAllGardensQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllGardensSpecification(request);
            var response = await _gardenService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
