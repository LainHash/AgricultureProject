using Agriculture.Domain.Abstraction;
using Agriculture.Domain.Entites.Guest;
using Agriculture.Domain.Entites.Templates;

namespace Agriculture.Domain.Entites.Territory
{
    public partial class Garden : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public int PlayerId { get; private set; }

        public virtual ICollection<GardenPlot> GardenPlots { get; private set; } = [];
        public virtual Player Player { get; private set; } = null!;
    }

    public partial class Garden
    {
        public Garden() { }

        public Garden(string name, string? description)
        {
            Name = name;
            Description = description;
        }

        public Garden(GardenTemplate template)
            : this(template.Name, template.Description)
        {
        }

        public static Garden UnlockHomeGarden()
        {
            return new Garden();
        }
    }
}
