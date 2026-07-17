using Agriculture.Domain.Entites.Identity;

namespace Agriculture.Domain.Repositories.Identity
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role?> FindAsync(string name, CancellationToken cancellationToken = default);
        Task<Role?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Role?> FindAsync(int id, CancellationToken cancellationToken = default);
    }
}
