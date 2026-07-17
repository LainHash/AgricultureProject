using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Territory.Gardens;
using MediatR;

namespace Agriculture.Application.Features.Territory.Gardens.GetById
{
    public record GetGardenByIdQuery(Guid Id)
        : IRequest<Result<GardenResponse>>
    {
    }
}
