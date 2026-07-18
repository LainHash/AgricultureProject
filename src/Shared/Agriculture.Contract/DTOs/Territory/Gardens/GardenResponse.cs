using Agriculture.Contract.DTOs.Territory.GardenPlots;

namespace Agriculture.Contract.DTOs.Territory.Gardens
{
    public class GardenResponse
    {
        public Guid PublicId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public IEnumerable<GardenPlotResponse> GardenPlots { get; set; } = [];
    }
}
