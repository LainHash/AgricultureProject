using Agriculture.Domain.Entites.Territory;

namespace Agriculture.Domain.Repositories.Territory
{
    public interface IGardenRepository : IRepository<Garden>
    {
        Task<Garden?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
