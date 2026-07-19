using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Repositories.Catalog;
using Agriculture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Persistence.Repositories.Catalog
{
    internal class PlantSpecicesRepository : Repository<PlantSpecices>, IPlantSpecicesRepository
    {
        private readonly AgricultureDbContext _context;
        public PlantSpecicesRepository(AgricultureDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PlantSpecices?> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.PlantSpecices.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<PlantSpecices?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.PlantSpecices.FirstOrDefaultAsync(x => x.PublicId == id, cancellationToken);
        }
    }
}
