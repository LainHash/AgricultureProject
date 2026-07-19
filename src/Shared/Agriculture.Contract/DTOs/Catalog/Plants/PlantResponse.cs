using Agriculture.Contract.DTOs.Catalog.PlantSpecices;

namespace Agriculture.Contract.DTOs.Catalog.Plants
{
    public class PlantResponse
    {
        public Guid PublicId { get; set; }
        public DateTime PlantAt { get; set; }
        public DateTime ExpectedHarvestAt { get; set; }
        public DateTime HarvestAt { get; set; }

        public decimal Health { get; set; }
        public decimal Moisture { get; set; }
        public decimal Fertilizer { get; set; }

        public bool IsDead { get; set; }

        public PlantSpecicesResponse PlantSpecices { get; set; } = null!;
    }
}
