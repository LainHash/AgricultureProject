using Agriculture.Application.Features.Guest.Players.Queries.GetAll;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Guest;
using Agriculture.Contract.DTOs.Guest.Players;
using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Repositories.Guest;

namespace Agriculture.Persistence.Services.Guest
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<Result<IEnumerable<PlayerResponse>>> GetAllAsync(GetAllPlayersSpecification specification, CancellationToken cancellationToken)
        {
            var players = await _playerRepository.ToListAsync(specification, cancellationToken);
            if (!players.Any())
            {
                return Result<IEnumerable<PlayerResponse>>
                    .Fail(Error<Player>.EmptyList);
            }

            var response = players.Select(x => new PlayerResponse(x));
            return Result<IEnumerable<PlayerResponse>>
                .Succeed(response, Success<Player>.Retrieved);
        }
    }
}
