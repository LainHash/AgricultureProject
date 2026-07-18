using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Repositories.Territory;
using Agriculture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Persistence.Repositories.Territory
{
    internal class GardenRepository : Repository<Garden>, IGardenRepository
    {
        private readonly AgricultureDbContext _context;
        public GardenRepository(AgricultureDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Garden?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Gardens.FirstOrDefaultAsync(x => x.PublicId == id, cancellationToken);
        }
    }
}
