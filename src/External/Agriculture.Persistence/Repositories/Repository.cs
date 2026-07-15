using Agriculture.Domain.Repositories;
using Agriculture.Domain.Specifications;
using Agriculture.Persistence.Contexts;
using Agriculture.Persistence.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Persistence.Repositories
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AgricultureDbContext _context;
        protected readonly DbSet<TEntity> Entity;

        public Repository(AgricultureDbContext context)
        {
            _context = context;
            Entity = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await Entity.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> ToListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(Entity, specification);
            return await query.ToListAsync(cancellationToken);
        }

        public async Task<TEntity?> FindAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(Entity, specification);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }
        public void Add(TEntity entity)
        {
            Entity.Add(entity);
        }

        public void Update(TEntity entity)
        {
            Entity.Update(entity);
        }
    }
}
