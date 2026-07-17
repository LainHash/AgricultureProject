using Agriculture.Domain.Abstraction;

namespace Agriculture.Domain.Entites.Territory
{
    public class GardenPlot : SoftDeletableEntity
    {
        public int GardenId { get; private set; }
        public int Row {  get; private set; }
        public int Column { get; private set; }
        public string SoilType { get; private set; } = string.Empty;
        public string Status { get; private set; } = string.Empty;

        public virtual Garden Garden { get; private set; } = null!;
    }
}
