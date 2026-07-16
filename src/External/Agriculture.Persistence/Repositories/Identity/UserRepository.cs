using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Repositories.Identity;
using Agriculture.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Agriculture.Persistence.Repositories.Identity
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AgricultureDbContext _context;
        public UserRepository(AgricultureDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> FindAsync(string emailOrUserName, CancellationToken cancellationToken = default)
        {
            return await _context.Users.FirstOrDefaultAsync(
                x => x.Username == emailOrUserName ||
                x.Email == emailOrUserName,
                cancellationToken);
        }
    }
}
