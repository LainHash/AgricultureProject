using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Repositories.Identity;
using Agriculture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

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

        public async Task<Role?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.PublicId == id, cancellationToken);
        }

        public async Task<Role?> FindAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Roles.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
