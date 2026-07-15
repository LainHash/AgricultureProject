using Agriculture.Domain.Abstraction;

namespace Agriculture.Domain.Entites.Catalog
{
    public class PlantSpecices : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string ScientificName { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public decimal GrowDays { get; private set; }
        public decimal HarvestDays { get; private set; }
        public decimal WaterIntervalHours { get; private set; }
        public decimal SunlightLevel { get; private set; }
        public decimal TemperatureMin { get; private set; }
        public decimal TemperatureMax { get; private set; }
    }
}
