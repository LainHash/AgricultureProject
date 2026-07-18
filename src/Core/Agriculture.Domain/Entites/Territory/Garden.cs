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

        public ICollection<GardenPlot> GardenPlots { get; private set; } = [];
        public Player Player { get; private set; } = null!;
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

        public Garden(GardenTemplate template, int playerId)
            : this(template)
        {
            PlayerId = playerId;
        }

        public static Garden FromTemplate(GardenTemplate template, int playerId)
        {
            var garden = new Garden(template, playerId);
            return garden;
        }


    }
}
