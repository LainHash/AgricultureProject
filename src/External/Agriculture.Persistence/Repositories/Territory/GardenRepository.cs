using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Repositories.Territory;
using Agriculture.Persistence.Contexts;

namespace Agriculture.Persistence.Repositories.Territory
{
    internal class GardenRepository : Repository<Garden>, IGardenRepository
    {
        public GardenRepository(AgricultureDbContext context) : base(context)
        {
        }
    }
}
