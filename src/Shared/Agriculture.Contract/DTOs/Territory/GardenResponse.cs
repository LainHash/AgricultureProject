namespace Agriculture.Contract.DTOs.Territory
{
    public class GardenResponse
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public IEnumerable<GardenPlotResponse> GardenPlots { get; set; } = [];
    }
}
