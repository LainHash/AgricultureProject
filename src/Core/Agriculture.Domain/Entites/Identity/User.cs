using Agriculture.Domain.Abstraction;
using Agriculture.Domain.Entites.Guest;

namespace Agriculture.Domain.Entites.Identity
{
    public class User : SoftDeletableEntity
    {
        public string Username { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public decimal Balance { get; private set; }

        public int RoleId { get; private set; }

        public virtual Role Role { get; private set; } = null!;
        public virtual Player Player { get; private set; } = null!;
    }
}
