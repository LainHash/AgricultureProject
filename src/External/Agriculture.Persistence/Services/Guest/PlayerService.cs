using Agriculture.Application.Features.Guest.Players.Queries.GetAll;
using Agriculture.Application.Features.Guest.Players.Queries.GetById;
using Agriculture.Application.Models.Messages;
using Agriculture.Application.Models.Results;
using Agriculture.Application.Services;
using Agriculture.Application.Services.Guest;
using Agriculture.Contract.DTOs.Authentication;
using Agriculture.Contract.DTOs.Guest.Players;
using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Repositories.Guest;
using Agriculture.Domain.Repositories.Templates;
using Agriculture.Domain.Repositories.Territory;
using Agriculture.Domain.Specifications;
using System.Net;

namespace Agriculture.Persistence.Services.Guest
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGardenRepository _gardenRepository;
        private readonly IGardenPlotRepository _gardenPlotRepository;
        private readonly IGardenTemplateRepository _gardenTemplateRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlayerService(
            IPlayerRepository playerRepository,
            IUnitOfWork unitOfWork,
            IGardenRepository gardenRepository,
            IGardenPlotRepository gardenPlotRepository,
            IGardenTemplateRepository gardenTemplateRepository)
        {
            _playerRepository = playerRepository;
            _unitOfWork = unitOfWork;
            _gardenRepository = gardenRepository;
            _gardenPlotRepository = gardenPlotRepository;
            _gardenTemplateRepository = gardenTemplateRepository;
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

        public async Task<Result<PlayerResponse>> GetByIdAsync(GetPlayerByIdSpecification specification, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.FindAsync(specification, cancellationToken);
            if (player is null)
            {
                return Result<PlayerResponse>
                    .Fail(Error<Player>.NotFound, HttpStatusCode.NotFound);
            }

            var response = new PlayerResponse(player);
            return Result<PlayerResponse>
                    .Succeed(response, Success<Player>.Retrieved);
        }

        public async Task InitializeAsync(int userId, CancellationToken cancellationToken)
        {
            var player = Player.Create(userId);
            _playerRepository.Add(player);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var specification = new GetHomeGardenTemplateSpecification();
            var homeGardenTemplate = await _gardenTemplateRepository.FindAsync(specification, cancellationToken);
            if (homeGardenTemplate is null)
            {
                throw new InvalidOperationException("Home garden template not found.");
            }

            var garden = Garden.FromTemplate(homeGardenTemplate, player.Id);
            _gardenRepository.Add(garden);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var plots = GardenPlot.FromTemplates(homeGardenTemplate.GardenPlotTemplates, garden.Id);
            _gardenPlotRepository.AddRange(plots);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task LoginAsync(int userId, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.FindByUserAsync(userId, cancellationToken)
                ?? throw new InvalidOperationException(Error<Player>.NotFound);

            player.MarkAsOnline();
            _playerRepository.Update(player);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task LogoutAsync(int userId, CancellationToken cancellationToken)
        {
            var player = await _playerRepository.FindByUserAsync(userId, cancellationToken)
                ?? throw new InvalidOperationException(Error<Player>.NotFound);
            
            player.MarkAsOffline();
            _playerRepository.Update(player);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }

        private class GetHomeGardenTemplateSpecification
            : BaseSpecification<GardenTemplate>
        {
            public GetHomeGardenTemplateSpecification()
            {
                Criteria = hg => hg.Name == "Home Garden";
                AddInclude(x => x.GardenPlotTemplates);
            }
        }
    }
}
