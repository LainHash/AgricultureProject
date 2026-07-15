using Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetAll;
using Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetById;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.PlantSpecices;

namespace Agriculture.Application.Services.Catalog
{
    public interface IPlantSpecicesService
    {
        Task<Result<IEnumerable<PlantSpecicesResponse>>> GetAllAsync(
            GetAllPlantSpecicesSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<PlantSpecicesResponse>> GetByIdAsync(
            GetPlantSpecicesByIdSpecification specification,
            CancellationToken cancellationToken);
    }
}
