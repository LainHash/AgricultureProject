using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Repositories.Catalog;
using Agriculture.Persistence.Contexts;

namespace Agriculture.Persistence.Repositories.Catalog
{
    internal class PlantSpecicesRepository : Repository<PlantSpecices>, IPlantSpecicesRepository
    {
        private readonly AgricultureDbContext _context;
        public PlantSpecicesRepository(AgricultureDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
