using Agriculture.Application.Services;
using Agriculture.Application.Services.Guest;
using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Repositories.Guest;
using Agriculture.Domain.Repositories.Templates;
using Agriculture.Domain.Repositories.Territory;
using Agriculture.Domain.Specifications;
using Microsoft.Extensions.Logging;

namespace Agriculture.Persistence.Services.Guest
{
    internal class PlayerInitializationService : IPlayerInitializationService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IGardenTemplateRepository _gardenTemplateRepository;
        private readonly IGardenRepository _gardenRepository;
        private readonly IGardenPlotRepository _gardenPlotRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PlayerInitializationService> _logger;

        public PlayerInitializationService(
            IPlayerRepository playerRepository,
            IUnitOfWork unitOfWork,
            IGardenTemplateRepository gardenTemplateRepository,
            IGardenRepository gardenRepository,
            IGardenPlotRepository gardenPlotRepository,
            ILogger<PlayerInitializationService> logger)
        {
            _playerRepository = playerRepository;
            _unitOfWork = unitOfWork;
            _gardenTemplateRepository = gardenTemplateRepository;
            _gardenRepository = gardenRepository;
            _gardenPlotRepository = gardenPlotRepository;
            _logger = logger;
        }

        public async Task InitializeAsync(User user, CancellationToken cancellationToken)
        {
            var player = Player.Create(user.Id);
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
