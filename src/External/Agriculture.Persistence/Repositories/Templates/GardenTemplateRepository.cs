using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Repositories.Templates;
using Agriculture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Persistence.Repositories.Templates
{
    internal class GardenTemplateRepository : Repository<GardenTemplate>, IGardenTemplateRepository
    {
        private readonly AgricultureDbContext _context;
        public GardenTemplateRepository(AgricultureDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<GardenTemplate?> FindAsync(string name, CancellationToken cancellationToken = default)
        {
            return await _context.GardenTemplates.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
        }
    }
}
