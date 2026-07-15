using Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetAll;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Catalog;
using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Repositories.Catalog;
using AutoMapper;

namespace Agriculture.Persistence.Services.Catalog
{
    internal class PlantSpecicesService : IPlantSpecicesService
    {
        private readonly IPlantSpecicesRepository _plantSpecicesRepository;
        private readonly IMapper _mapper;

        public PlantSpecicesService(
            IPlantSpecicesRepository plantSpecicesRepository,
            IMapper mapper)
        {
            _plantSpecicesRepository = plantSpecicesRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<PlantSpecicesResponse>>> GetAllAsync(
            GetAllPlantSpecicesSpecification specification,
            CancellationToken cancellationToken)
        {
            var specices = await _plantSpecicesRepository.ToListAsync(specification, cancellationToken);

            if(specices.Count() == 0)
            {
                return Result<IEnumerable<PlantSpecicesResponse>>
                    .Fail(Error<PlantSpecices>.EmptyList);
            }

            var response = _mapper.Map<IEnumerable<PlantSpecicesResponse>>(specices);
            return Result<IEnumerable<PlantSpecicesResponse>>
                .Succeed(response, Success<PlantSpecices>.Retrieved);
        }
    }
}
