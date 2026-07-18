namespace Agriculture.Contract.DTOs.Catalog.PlantSpecices
{
    public class PlantSpecicesResponse
    {
        public Guid PublicId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string ScientificName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal GrowDays { get; set; }
        public decimal HarvestDays { get; set; }
        public decimal WaterIntervalHours { get; set; }
        public decimal SunlightLevel { get; set; }
        public decimal TemperatureMin { get; set; }
        public decimal TemperatureMax { get; set; }
    }
}
