namespace Agriculture.Contract.DTOs.Territory.GardenPlots
{
    public class AddGardenPlotRequest
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string SoilType { get; set; } = string.Empty;
    }
}
