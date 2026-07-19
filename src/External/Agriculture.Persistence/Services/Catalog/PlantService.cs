using Agriculture.Application.Features.Catalog.Plants.Queries.GetAll;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.Plants;
using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Repositories.Catalog;
using AutoMapper;

namespace Agriculture.Persistence.Services.Catalog
{
    internal class PlantService : IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IMapper _mapper;

        public PlantService(
            IPlantRepository plantRepository,
            IMapper mapper)
        {
            _plantRepository = plantRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<PLantResponse>>> GetAllAsync(
            GetAllPlantsSpecification specification,
            CancellationToken cancellationToken)
        {
            var plants = await _plantRepository.ToListAsync(specification, cancellationToken);
            if (!plants.Any())
            {
                return Result<IEnumerable<PLantResponse>>
                    .Fail(Error<Plant>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<PLantResponse>>(plants);
            return Result<IEnumerable<PLantResponse>>
                .Succeed(response, Success<Plant>.Retrieved);
        }
    }
}
