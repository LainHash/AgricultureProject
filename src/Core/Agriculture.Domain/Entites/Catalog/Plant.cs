using Agriculture.Domain.Abstraction;
using Agriculture.Domain.Entites.Territory;

namespace Agriculture.Domain.Entites.Catalog
{
    public class Plant : SoftDeletableEntity
    {
        public int CategoryId { get; private set; }
        public int PlantSpecicesId { get; private set; }
        public int GardenPlotId { get; private set; }

        public DateTime PlantAt { get; private set; }
        public DateTime ExpectedHarvestAt { get; private set; }
        public DateTime HarvestAt { get; private set; }

        public decimal Health { get; private set; }
        public decimal Moisture { get; private set; }
        public decimal Fertilizer { get; private set; }

        public bool IsDead { get; private set; }

        public Category Category { get; private set; } = null!;
        public PlantSpecices PlantSpecices { get; private set; } = null!;
        public GardenPlot GardenPlot { get; private set; } = null!;
    }
}
