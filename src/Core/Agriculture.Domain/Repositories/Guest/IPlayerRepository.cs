using Agriculture.Domain.Entites.Guest;

namespace Agriculture.Domain.Repositories.Guest
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<Player?> FindByUserAsync(int id, CancellationToken cancellationToken = default);
    }
}
