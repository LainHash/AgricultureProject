using Agriculture.Domain.Entites.Catalog;

namespace Agriculture.Domain.Repositories.Catalog
{
    public interface IPlantSpecicesRepository : IRepository<PlantSpecices>
    {
        Task<PlantSpecices?> FindAsync(int id, CancellationToken cancellationToken = default);
        Task<PlantSpecices?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
