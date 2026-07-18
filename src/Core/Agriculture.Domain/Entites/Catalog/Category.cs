using Agriculture.Domain.Abstraction;

namespace Agriculture.Domain.Entites.Catalog
{
    public class Category : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public ICollection<PlantSpecices> PlantSpecices { get; private set; } = [];
    }
}
