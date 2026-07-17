using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Repositories.Territory;
using Agriculture.Persistence.Contexts;

namespace Agriculture.Persistence.Repositories.Territory
{
    internal class GardenPlotRepository : Repository<GardenPlot>, IGardenPlotRepository
    {
        public GardenPlotRepository(AgricultureDbContext context) : base(context)
        {
        }
    }
}
