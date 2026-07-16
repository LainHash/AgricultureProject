using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Repositories.Guest;
using Agriculture.Persistence.Contexts;

namespace Agriculture.Persistence.Repositories.Guest
{
    internal class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(AgricultureDbContext context) : base(context)
        {
        }
    }
}
