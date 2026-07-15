using System;

namespace Agriculture.Domain.Abstraction
{
    public abstract class Entity
    {
        public int Id { get; }
        public Guid PublicId { get; private set; }
        protected Entity()
        {
            PublicId = new Guid();
        }
    }

    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; protected set; } = DateTime.UtcNow;

        public void MarkCreated(DateTime now)
        {
            CreatedAt = now;
            UpdatedAt = now;
        }

        public void MarkUpdated(DateTime now)
        {
            UpdatedAt = now;
        }
    }

    public abstract class SoftDeletableEntity : AuditableEntity
    {
        public bool IsDeleted { get; protected set; } = false;
        public DateTime? DeletedAt { get; protected set; } = null;
        public void SoftDelete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        public void Restore()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
