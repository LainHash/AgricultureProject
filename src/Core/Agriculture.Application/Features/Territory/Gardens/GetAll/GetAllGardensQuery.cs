using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Territory;
using MediatR;

namespace Agriculture.Application.Features.Territory.Gardens.GetAll
{
    public record GetAllGardensQuery
        : IRequest<Result<IEnumerable<GardenResponse>>>
    {
    }
}
