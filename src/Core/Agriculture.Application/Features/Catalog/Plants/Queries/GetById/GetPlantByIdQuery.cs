using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Plants;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Plants.Queries.GetById
{
    public record GetPlantByIdQuery(Guid Id)
        : IRequest<Result<PlantResponse>>
    {
    }
}
