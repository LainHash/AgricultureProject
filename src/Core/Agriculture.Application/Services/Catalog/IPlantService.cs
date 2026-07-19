using Agriculture.Application.Features.Catalog.Plants.Queries.GetAll;
using Agriculture.Application.Features.Catalog.Plants.Queries.GetById;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Plants;

namespace Agriculture.Application.Services.Catalog
{
    public interface IPlantService
    {
        Task<Result<IEnumerable<PlantResponse>>> GetAllAsync(
            GetAllPlantsSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<PlantResponse>> GetByIdAsync(
            GetPlantByIdSpecification specification,
            CancellationToken cancellationToken);
    }
}
