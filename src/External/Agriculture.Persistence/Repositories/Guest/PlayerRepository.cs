using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Repositories.Guest;
using Agriculture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Persistence.Repositories.Guest
{
    internal class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        private readonly AgricultureDbContext _context;
        public PlayerRepository(AgricultureDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Player?> FindByUserAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Players.FirstOrDefaultAsync(x => x.UserId == id, cancellationToken);
        }
    }
}
