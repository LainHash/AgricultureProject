namespace Agriculture.Contract.DTOs.Templates.GardenPlotTemplates
{
    public class GardenPlotTemplateResponse
    {
        public Guid PublicId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public string SoilType { get; set; } = string.Empty;
    }
}
