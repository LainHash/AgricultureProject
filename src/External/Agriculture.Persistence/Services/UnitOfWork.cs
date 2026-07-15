using Agriculture.Application.Services;
using Agriculture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Agriculture.Persistence.Services
{
    internal class UnitOfWork(AgricultureDbContext context) : IUnitOfWork
    {
        private readonly AgricultureDbContext _context = context;

        public Task<IDbContextTransaction> BeginTransactionAsync(
            CancellationToken cancellationToken = default)
        {
            return _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
