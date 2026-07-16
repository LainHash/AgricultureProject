using Agriculture.Domain.Entites.Identity;

namespace Agriculture.Domain.Repositories.Identity
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role?> FindAsync(string name, CancellationToken cancellationToken);
    }
}
