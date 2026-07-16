using Agriculture.Domain.Abstraction;
using Agriculture.Domain.Entites.Identity;

namespace Agriculture.Domain.Entites.Guest
{
    public class Player : SoftDeletableEntity
    {
        public int UserId { get; private set; }

        public virtual User User { get; private set; } = null!;
    }
}
