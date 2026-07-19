using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.Plants;
using MediatR;

namespace Agriculture.Application.Features.Catalog.Plants.Queries.GetAll
{
    public record GetAllPlantsQuery
        : IRequest<Result<IEnumerable<PLantResponse>>>
    {
    }
}
