namespace Agriculture.Contract.DTOs.Territory
{
    public class GardenPlotResponse
    {
        public int GardenId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string SoilType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
