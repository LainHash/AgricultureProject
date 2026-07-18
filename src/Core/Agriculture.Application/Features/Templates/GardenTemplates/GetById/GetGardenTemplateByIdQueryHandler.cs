using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Templates;
using Agriculture.Contract.DTOs.Templates.GardenTemplates;
using MediatR;

namespace Agriculture.Application.Features.Templates.GardenTemplates.GetById
{
    internal class GetGardenTemplateByIdQueryHandler
        : IRequestHandler<GetGardenTemplateByIdQuery, Result<GardenTemplateResponse>>
    {
        private readonly IGardenTemplateService _gardenTemplateService;

        public GetGardenTemplateByIdQueryHandler(IGardenTemplateService gardenTemplateService)
        {
            _gardenTemplateService = gardenTemplateService;
        }

        public async Task<Result<GardenTemplateResponse>> Handle(GetGardenTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetGardenTemplateByIdSpecification(request);
            var response = await _gardenTemplateService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
