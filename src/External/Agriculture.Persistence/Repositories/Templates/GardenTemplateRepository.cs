using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Repositories.Templates;
using Agriculture.Persistence.Contexts;

namespace Agriculture.Persistence.Repositories.Templates
{
    internal class GardenTemplateRepository : Repository<GardenTemplate>, IGardenTemplateRepository
    {
        public GardenTemplateRepository(AgricultureDbContext context) : base(context)
        {
        }
    }
}
