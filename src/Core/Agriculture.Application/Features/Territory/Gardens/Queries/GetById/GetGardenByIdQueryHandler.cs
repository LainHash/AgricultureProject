using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Territory;
using Agriculture.Contract.DTOs.Territory.Gardens;
using MediatR;

namespace Agriculture.Application.Features.Territory.Gardens.Queries.GetById
{
    internal class GetGardenByIdQueryHandler
        : IRequestHandler<GetGardenByIdQuery, Result<GardenResponse>>
    {
        private readonly IGardenService _gardenService;

        public GetGardenByIdQueryHandler(IGardenService gardenService)
        {
            _gardenService = gardenService;
        }

        public async Task<Result<GardenResponse>> Handle(GetGardenByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetGardenByIdSpecification(request);
            var response = await _gardenService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
