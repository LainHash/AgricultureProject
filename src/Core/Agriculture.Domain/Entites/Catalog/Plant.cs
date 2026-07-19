using Agriculture.Domain.Abstraction;
using Agriculture.Domain.Entites.Territory;

namespace Agriculture.Domain.Entites.Catalog
{
    public partial class Plant : SoftDeletableEntity
    {
        public int PlantSpecicesId { get; private set; }
        public int GardenPlotId { get; private set; }

        public DateTime PlantAt { get; private set; }
        public DateTime ExpectedHarvestAt { get; private set; }
        public DateTime? HarvestAt { get; private set; }

        public decimal Health { get; private set; }
        public decimal Moisture { get; private set; }
        public decimal Fertilizer { get; private set; }

        public bool IsDead { get; private set; }

        public PlantSpecices PlantSpecices { get; private set; } = null!;
        public GardenPlot GardenPlot { get; private set; } = null!;
    }

    public partial class Plant
    {
        public Plant()
        {
            PlantAt = DateTime.UtcNow;
            Health = 100;
            Moisture = 100;
            Fertilizer = 100;
        }

        public Plant(int specicesId, int plotId)
        {
            PlantSpecicesId = specicesId;
            GardenPlotId = plotId;
        }

        public void SetExpectedHarvestAt(decimal days)
        {
            ExpectedHarvestAt = DateTime.UtcNow.AddDays((double)days);
        }
    }
}
