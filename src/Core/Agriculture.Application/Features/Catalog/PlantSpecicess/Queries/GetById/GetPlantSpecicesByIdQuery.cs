using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using MediatR;

namespace Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetById
{
    public record GetPlantSpecicesByIdQuery(Guid Id)
        : IRequest<Result<PlantSpecicesResponse>>
    {
    }
}
