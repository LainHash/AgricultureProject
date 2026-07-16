using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Guest.Players;
using MediatR;

namespace Agriculture.Application.Features.Guest.Players.Queries.GetAll
{
    public record GetAllPlayersQuery()
        : IRequest<Result<IEnumerable<PlayerResponse>>>
    {
    }
}
