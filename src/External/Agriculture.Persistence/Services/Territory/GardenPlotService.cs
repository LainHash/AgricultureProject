using Agriculture.Application.Features.Territory.GardenPlots.Commands.Planting;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services;
using Agriculture.Application.Services.Territory;
using Agriculture.Contract.DTOs.Catalog.Plants;
using Agriculture.Contract.DTOs.Territory.GardenPlots;
using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Repositories.Catalog;
using Agriculture.Domain.Repositories.Territory;
using AutoMapper;
using System.Net;

namespace Agriculture.Persistence.Services.Territory
{
    internal class GardenPlotService : IGardenPlotService
    {
        private readonly IGardenPlotRepository _gardenPlotRepository;
        private readonly IPlantSpecicesRepository _plantSpecicesRepository;
        private readonly IPlantRepository _plantRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GardenPlotService(
            IGardenPlotRepository gardenPlotRepository,
            IMapper mapper,
            IPlantSpecicesRepository plantSpecicesRepository,
            IPlantRepository plantRepository,
            IUnitOfWork unitOfWork)
        {
            _gardenPlotRepository = gardenPlotRepository;
            _mapper = mapper;
            _plantSpecicesRepository = plantSpecicesRepository;
            _plantRepository = plantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GardenPlotResponse>> PlantAsync(
            PlantingSpecification specification,
            CancellationToken cancellationToken)
        {
            var plot = await _gardenPlotRepository.FindAsync(specification, cancellationToken);
            if(plot is null)
            {
                return Result<GardenPlotResponse>
                    .Fail(Error<GardenPlot>.NotFound, HttpStatusCode.InternalServerError);
            }

            if(plot.Plant is not null)
            {
                return Result<GardenPlotResponse>
                    .Fail(Error<GardenPlot>.Occupied, HttpStatusCode.Conflict);
            }

            var specices = await _plantSpecicesRepository.FindAsync(specification.SpecicesId, cancellationToken);
            if (specices is null)
            {
                return Result<GardenPlotResponse>
                    .Fail(Error<PlantSpecices>.NotFound, HttpStatusCode.InternalServerError);
            }

            var plant = new Plant(specices.Id, plot.Id);
            plant.SetExpectedHarvestAt(specices.HarvestDays);
            _plantRepository.Add(plant);

            plot.SetOccupied();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var plantedPlot = await _gardenPlotRepository.FindAsync(specification, cancellationToken);

            var response = _mapper.Map<GardenPlotResponse>(plantedPlot);
            return Result<GardenPlotResponse>
                .Succeed(response, Success<Plant>.Planted);
        }
    }
}
