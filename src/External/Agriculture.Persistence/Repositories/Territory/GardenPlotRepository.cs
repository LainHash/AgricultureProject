using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Repositories.Territory;
using Agriculture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Persistence.Repositories.Territory
{
    internal class GardenPlotRepository : Repository<GardenPlot>, IGardenPlotRepository
    {
        private readonly AgricultureDbContext _context;
        public GardenPlotRepository(AgricultureDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GardenPlot?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.GardenPlots.FirstOrDefaultAsync(x => x.PublicId == id, cancellationToken);
        }
    }
}
