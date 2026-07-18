using Agriculture.Application.Features.Templates.GardenTemplates.GetAll;
using Agriculture.Application.Features.Templates.GardenTemplates.GetById;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Templates;
using Agriculture.Contract.DTOs.Templates.GardenTemplates;
using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Repositories.Templates;
using AutoMapper;
using System.Net;

namespace Agriculture.Persistence.Services.Templates
{
    internal class GardenTemplateService : IGardenTemplateService
    {
        private readonly IGardenTemplateRepository _gardenTemplateRepository;
        private readonly IMapper _mapper;

        public GardenTemplateService(
            IGardenTemplateRepository gardenTemplateRepository,
            IMapper mapper)
        {
            _gardenTemplateRepository = gardenTemplateRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<GardenTemplateResponse>>> GetAllAsync(
            GetAllGardenTemplatesSpecification specification,
            CancellationToken cancellationToken)
        {
            var templates = await _gardenTemplateRepository.ToListAsync(specification, cancellationToken);
            if (!templates.Any())
            {
                return Result<IEnumerable<GardenTemplateResponse>>
                    .Fail(Error<GardenTemplate>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<GardenTemplateResponse>>(templates);
            return Result<IEnumerable<GardenTemplateResponse>>
                .Succeed(response, Success<GardenTemplate>.Retrieved);
        }

        public async Task<Result<GardenTemplateResponse>> GetByIdAsync(
            GetGardenTemplateByIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var template = await _gardenTemplateRepository.FindAsync(specification, cancellationToken);
            if (template is null)
            {
                return Result<GardenTemplateResponse>
                    .Fail(Error<GardenTemplate>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<GardenTemplateResponse>(template);
            return Result<GardenTemplateResponse>
                .Succeed(response, Success<GardenTemplate>.Retrieved);
        }
    }
}
