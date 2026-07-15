using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Repositories;
using Agriculture.Domain.Repositories.Catalog;
using Agriculture.Persistence.Contexts;

namespace Agriculture.Persistence.Repositories.Catalog
{
    internal class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AgricultureDbContext context) : base(context)
        {
        }
    }
}
