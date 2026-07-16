using Agriculture.Application.Features.Guest.Players.Queries.GetAll;
using Agriculture.Application.Features.Guest.Players.Queries.GetById;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Guest.Players;

namespace Agriculture.Application.Services.Guest
{
    public interface IPlayerService
    {
        Task<Result<IEnumerable<PlayerResponse>>> GetAllAsync(
            GetAllPlayersSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<PlayerResponse>> GetByIdAsync(
            GetPlayerByIdSpecification specification,
            CancellationToken cancellationToken);
    }
}
