using Agriculture.Application.Models.Results;
using Agriculture.Application.Services.Guest;
using Agriculture.Contract.DTOs.Guest.Players;
using MediatR;

namespace Agriculture.Application.Features.Guest.Players.Queries.GetById
{
    internal class GetPlayerByIdQueryHandler
        : IRequestHandler<GetPlayerByIdQuery, Result<PlayerResponse>>
    {
        private readonly IPlayerService _playerService;

        public GetPlayerByIdQueryHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<Result<PlayerResponse>> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetPlayerByIdSpecification(request);
            var response = await _playerService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
