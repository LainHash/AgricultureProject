using Agriculture.Domain.Entites.Territory;

namespace Agriculture.Domain.Repositories.Territory
{
    public interface IGardenPlotRepository : IRepository<GardenPlot>
    {
        Task<GardenPlot?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
