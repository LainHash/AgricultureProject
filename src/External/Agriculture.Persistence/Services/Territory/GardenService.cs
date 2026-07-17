using Agriculture.Application.Features.Territory.Gardens.GetAll;
using Agriculture.Application.Features.Territory.Gardens.GetById;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Territory;
using Agriculture.Contract.DTOs.Territory;
using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Repositories.Territory;
using AutoMapper;
using System.Net;

namespace Agriculture.Persistence.Services.Territory
{
    internal class GardenService : IGardenService
    {
        private readonly IGardenRepository _gardenRepository;
        private readonly IMapper _mapper;

        public GardenService(
            IGardenRepository gardenRepository,
            IMapper mapper)
        {
            _gardenRepository = gardenRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<GardenResponse>>> GetAllAsync(
            GetAllGardensSpecification specification,
            CancellationToken cancellationToken)
        {
            var gardens = await _gardenRepository.ToListAsync(specification, cancellationToken);
            if (!gardens.Any())
            {
                return Result<IEnumerable<GardenResponse>>
                    .Fail(Error<Garden>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<GardenResponse>>(gardens);
            return Result<IEnumerable<GardenResponse>>
                .Succeed(response, Success<Garden>.Retrieved);
        }

        public async Task<Result<GardenResponse>> GetByIdAsync(GetGardenByIdSpecification specification, CancellationToken cancellationToken)
        {
            var garden = await _gardenRepository.FindAsync(specification, cancellationToken);
            if (garden is null)
            {
                return Result<GardenResponse>
                    .Fail(Error<Garden>.NotFound, HttpStatusCode.NotFound);
            }

            var response = _mapper.Map<GardenResponse>(garden);
            return Result<GardenResponse>
                .Succeed(response, Success<Garden>.Retrieved);
        }
    }
}
