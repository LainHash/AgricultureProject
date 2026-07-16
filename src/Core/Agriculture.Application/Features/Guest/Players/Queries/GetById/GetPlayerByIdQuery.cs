using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Guest.Players;
using MediatR;

namespace Agriculture.Application.Features.Guest.Players.Queries.GetById
{
    public record GetPlayerByIdQuery(Guid Id)
        : IRequest<Result<PlayerResponse>>
    {
    }
}
