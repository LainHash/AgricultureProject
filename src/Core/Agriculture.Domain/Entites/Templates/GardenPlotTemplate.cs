using Agriculture.Domain.Abstraction;

namespace Agriculture.Domain.Entites.Templates
{
    public class GardenPlotTemplate : SoftDeletableEntity
    {
        public int GardenTemplateId { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public string SoilType { get; private set; } = string.Empty;

        public virtual GardenTemplate GardenTemplate { get; private set; } = null!;
    }
}
