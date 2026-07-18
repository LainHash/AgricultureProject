using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Territory;
using Agriculture.Contract.DTOs.Territory.Gardens;
using MediatR;

namespace Agriculture.Application.Features.Territory.Gardens.Commands.AddPlot
{
    internal class AddGardenPlotsCommandHandler
        : IRequestHandler<AddGardenPlotsCommand, Result<GardenResponse>>
    {
        private readonly IGardenService _gardenService;

        public AddGardenPlotsCommandHandler(IGardenService gardenService)
        {
            _gardenService = gardenService;
        }

        public async Task<Result<GardenResponse>> Handle(AddGardenPlotsCommand request, CancellationToken cancellationToken)
        {
            var specification = new AddGardenPlotsSpecification(request);
            var response = await _gardenService.AddPlotsAsync(specification, cancellationToken);
            return response;
        }
    }
}
