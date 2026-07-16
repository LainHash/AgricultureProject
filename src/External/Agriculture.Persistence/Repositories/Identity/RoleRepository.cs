using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Repositories.Identity;
using Agriculture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Persistence.Repositories.Identity
{
    internal class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly AgricultureDbContext _context;
        public RoleRepository(AgricultureDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Role?> FindAsync(string name, CancellationToken cancellationToken)
        {
           return await _context.Roles.FirstOrDefaultAsync(x => x.Name == name, cancellationToken);
        }
    }
}
