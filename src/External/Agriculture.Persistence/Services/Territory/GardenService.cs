using Agriculture.Application.Features.Territory.Gardens.Commands.AddPlot;
using Agriculture.Application.Features.Territory.Gardens.Queries.GetAll;
using Agriculture.Application.Features.Territory.Gardens.Queries.GetById;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services;
using Agriculture.Application.Services.Territory;
using Agriculture.Contract.DTOs.Territory.Gardens;
using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Repositories.Territory;
using AutoMapper;
using System.Net;

namespace Agriculture.Persistence.Services.Territory
{
    internal class GardenService : IGardenService
    {
        private readonly IGardenRepository _gardenRepository;
        private readonly IGardenPlotRepository _gardenPlotRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GardenService(
            IGardenRepository gardenRepository,
            IMapper mapper,
            IGardenPlotRepository gardenPlotRepository,
            IUnitOfWork unitOfWork)
        {
            _gardenRepository = gardenRepository;
            _mapper = mapper;
            _gardenPlotRepository = gardenPlotRepository;
            _unitOfWork = unitOfWork;
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

        public async Task<Result<GardenResponse>> AddPlotsAsync(AddGardenPlotsSpecification specification, CancellationToken cancellationToken)
        {
            var garden = await _gardenRepository.FindAsync(specification.GardenId, cancellationToken);
            if (garden is null)
            {
                return Result<GardenResponse>
                    .Fail(Error<Garden>.NotFound, HttpStatusCode.NotFound);
            }

            var plots = specification.Body.Select(x => new GardenPlot(_mapper.Map<GardenPlot>(x), garden.Id));
            _gardenPlotRepository.AddRange(plots);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            specification.ApplyCriteria(garden.Id);
            var addedPlotGarden = await _gardenRepository.FindAsync(specification, cancellationToken);

            var response = _mapper.Map<GardenResponse>(addedPlotGarden);
            return Result<GardenResponse>
                .Succeed(response, Success<GardenPlot>.Added, HttpStatusCode.Accepted);

        }
    }
}
