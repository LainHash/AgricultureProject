using Agriculture.Application.Features.Catalog.Plants.Queries.GetAll;
using Agriculture.Application.Features.Catalog.Plants.Queries.GetById;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.Plants;
using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Repositories.Catalog;
using Agriculture.Domain.Repositories.Territory;
using AutoMapper;
using System.Net;

namespace Agriculture.Persistence.Services.Catalog
{
    internal class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlantService(
            IPlantRepository plantRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _plantRepository = plantRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<PlantResponse>>> GetAllAsync(
            GetAllPlantsSpecification specification,
            CancellationToken cancellationToken)
        {
            var plants = await _plantRepository.ToListAsync(specification, cancellationToken);
            if (!plants.Any())
            {
                return Result<IEnumerable<PlantResponse>>
                    .Fail(Error<Plant>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<PlantResponse>>(plants);
            return Result<IEnumerable<PlantResponse>>
                .Succeed(response, Success<Plant>.Retrieved);
        }

        public async Task<Result<PlantResponse>> GetByIdAsync(
            GetPlantByIdSpecification specification,
            CancellationToken cancellationToken)
        {
            var plant = await _plantRepository.FindAsync(specification, cancellationToken);
            if(plant is null)
            {
                return Result<PlantResponse>
                    .Fail(Error<Plant>.NotFound, HttpStatusCode.InternalServerError);
            }

            var response = _mapper.Map<PlantResponse>(plant);
            return Result<PlantResponse>
                .Succeed(response, Success<Plant>.Retrieved);
        }
    }
}
