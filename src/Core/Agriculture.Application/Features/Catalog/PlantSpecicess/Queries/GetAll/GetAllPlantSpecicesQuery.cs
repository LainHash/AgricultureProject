using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using MediatR;

namespace Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetAll
{
    public record GetAllPlantSpecicesQuery
        : IRequest<Result<IEnumerable<PlantSpecicesResponse>>>
    {
    }
}
