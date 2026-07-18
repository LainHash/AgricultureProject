using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Templates;
using Agriculture.Contract.DTOs.Templates.GardenTemplates;
using MediatR;

namespace Agriculture.Application.Features.Templates.GardenTemplates.Queries.GetAll
{
    internal class GetAllGardenTemplatesQueryHandler
        : IRequestHandler<GetAllGardenTemplatesQuery, Result<IEnumerable<GardenTemplateResponse>>>
    {
        private readonly IGardenTemplateService _gardenTemplateService;

        public GetAllGardenTemplatesQueryHandler(IGardenTemplateService gardenTemplateService)
        {
            _gardenTemplateService = gardenTemplateService;
        }

        public async Task<Result<IEnumerable<GardenTemplateResponse>>> Handle(GetAllGardenTemplatesQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllGardenTemplatesSpecification(request);
            var response = await _gardenTemplateService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
