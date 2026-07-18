using Agriculture.Application.Features.Territory.Gardens.Commands.AddPlot;
using Agriculture.Application.Features.Territory.Gardens.Queries.GetAll;
using Agriculture.Application.Features.Territory.Gardens.Queries.GetById;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Territory.Gardens;

namespace Agriculture.Application.Services.Territory
{
    public interface IGardenService
    {
        Task<Result<IEnumerable<GardenResponse>>> GetAllAsync(
            GetAllGardensSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<GardenResponse>> GetByIdAsync(
            GetGardenByIdSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<GardenResponse>> AddPlotsAsync(
            AddGardenPlotsSpecification specification,
            CancellationToken cancellationToken);
    }
}
