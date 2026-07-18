using Agriculture.Domain.Entites.Templates;

namespace Agriculture.Domain.Repositories.Templates
{
    public interface IGardenTemplateRepository : IRepository<GardenTemplate>
    {
        Task<GardenTemplate?> FindAsync(string name, CancellationToken cancellationToken = default);
    }
}
