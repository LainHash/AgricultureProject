using Agriculture.Contract.DTOs.Catalog.Plants;

namespace Agriculture.Contract.DTOs.Territory.GardenPlots
{
    public class GardenPlotResponse
    {
        public Guid PublicId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string SoilType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public PlantResponse? Plant { get; set; }
    }
}
