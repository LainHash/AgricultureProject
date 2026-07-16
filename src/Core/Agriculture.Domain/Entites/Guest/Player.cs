using Agriculture.Domain.Abstraction;
using Agriculture.Domain.Entites.Identity;

namespace Agriculture.Domain.Entites.Guest
{
    public partial class Player : SoftDeletableEntity
    {
        public int UserId { get; private set; }

        public virtual User User { get; private set; } = null!;
    }

    public partial class Player
    {
        public void SetUser(int userId)
        {
            UserId = userId;
        }

        public static Player Create(int userId)
        {
            return new Player()
            {
                UserId = userId
            };
        }
    }
}
