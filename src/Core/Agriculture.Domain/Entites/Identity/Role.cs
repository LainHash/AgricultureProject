using Agriculture.Domain.Abstraction;

namespace Agriculture.Domain.Entites.Identity
{
    public class Role : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public virtual ICollection<User> Users { get; private set; } = [];
    }
}
