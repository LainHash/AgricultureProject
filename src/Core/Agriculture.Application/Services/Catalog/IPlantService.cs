using Agriculture.Application.Features.Catalog.Plants.Queries.GetAll;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Plants;

namespace Agriculture.Application.Services.Catalog
{
    public interface IPlantService
    {
        Task<Result<IEnumerable<PLantResponse>>> GetAllAsync(
            GetAllPlantsSpecification specification,
            CancellationToken cancellationToken);
    }
}
