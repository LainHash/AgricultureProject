using Agriculture.Domain.Entites.Identity;

namespace Agriculture.Domain.Repositories.Identity
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> FindAsync(string emailOrUserName, CancellationToken cancellationToken = default);
        Task<User?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
