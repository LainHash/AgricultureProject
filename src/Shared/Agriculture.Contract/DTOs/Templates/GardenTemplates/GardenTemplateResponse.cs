using Agriculture.Contract.DTOs.Templates.GardenPlotTemplates;

namespace Agriculture.Contract.DTOs.Templates.GardenTemplates
{
    public class GardenTemplateResponse
    {
        public Guid PublicId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public string UnlockType { get; set; } = string.Empty;
        public decimal UnlockValue { get; set; }
        public decimal UnlockPrice { get; set; }

        public int? ReferenceId { get; set; }

        public IEnumerable<GardenPlotTemplateResponse> GardenPlotTemplates { get; set; } = [];
    }
}
