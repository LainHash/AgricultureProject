using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Guest;
using Agriculture.Contract.DTOs.Guest.Players;
using MediatR;

namespace Agriculture.Application.Features.Guest.Players.Queries.GetAll
{
    internal class GetAllPlayersQueryHandler
        : IRequestHandler<GetAllPlayersQuery, Result<IEnumerable<PlayerResponse>>>
    {
        private readonly IPlayerService _playerService;

        public GetAllPlayersQueryHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<Result<IEnumerable<PlayerResponse>>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllPlayersSpecification(request);
            var response = await _playerService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
