using Agriculture.Domain.Abstraction;

namespace Agriculture.Domain.Entites.Catalog
{
    public class Category : SoftDeletableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
