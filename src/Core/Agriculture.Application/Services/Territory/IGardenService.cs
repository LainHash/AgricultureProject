using Agriculture.Application.Features.Territory.Gardens.GetAll;
using Agriculture.Application.Features.Territory.Gardens.GetById;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Territory;

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
    }
}
