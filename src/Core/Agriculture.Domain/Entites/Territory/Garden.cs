using Agriculture.Domain.Abstraction;

namespace Agriculture.Domain.Entites.Territory
{
    public class Garden : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public virtual ICollection<GardenPlot> GardenPlots { get; private set; } = [];
    }
}
