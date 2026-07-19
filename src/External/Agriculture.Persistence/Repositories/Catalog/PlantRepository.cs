using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Repositories.Catalog;
using Agriculture.Persistence.Contexts;

namespace Agriculture.Persistence.Repositories.Catalog
{
    internal class PlantRepository : Repository<Plant>, IPlantRepository
    {
        public PlantRepository(AgricultureDbContext context) : base(context)
        {
        }
    }
}
