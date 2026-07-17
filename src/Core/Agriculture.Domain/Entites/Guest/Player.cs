using Agriculture.Domain.Abstraction;
using Agriculture.Domain.Entites.Identity;
using Agriculture.Domain.Entites.Territory;

namespace Agriculture.Domain.Entites.Guest
{
    public partial class Player : SoftDeletableEntity
    {
        public int UserId { get; private set; }

        public string Nickname { get; private set; } = string.Empty;
        public int Level { get; private set; }
        public int Experience { get; private set; }
        public int Gold { get; private set; }
        public int Gem { get; private set; }
        public decimal Energy { get; private set; }
        public DateTime LastLoginAt { get; private set; }

        public virtual User User { get; private set; } = null!;
        public virtual ICollection<Garden> Gardens { get; private set; } = [];
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
