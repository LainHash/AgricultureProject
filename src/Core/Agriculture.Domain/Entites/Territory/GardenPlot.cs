using Agriculture.Domain.Abstraction;
using Agriculture.Domain.Entites.Templates;
using Agriculture.Domain.Enums;

namespace Agriculture.Domain.Entites.Territory
{
    public partial class GardenPlot : SoftDeletableEntity
    {
        public int GardenId { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public string SoilType { get; private set; } = string.Empty;
        public string Status { get; private set; } = string.Empty;

        public virtual Garden Garden { get; private set; } = null!;
    }

    public partial class GardenPlot
    {
        public GardenPlot() { }

        public GardenPlot(int row, int column, string soilType, string status = nameof(GardenPlotStatus.Empty))
        {
            Row = row;
            Column = column;
            SoilType = soilType;
            Status = status;
        }

        public GardenPlot(int gardenId, int row, int column, string soilType, string status = nameof(GardenPlotStatus.Empty))
            : this(row, column, soilType, status)
        {
            GardenId = gardenId;
        }

        public GardenPlot(GardenPlot plot)
        {
            Row = plot.Row;
            Column = plot.Column;
            SoilType = plot.SoilType;
            Status = nameof(GardenPlotStatus.Empty);
        }

        public GardenPlot(GardenPlot plot, int gardenId)
            : this(plot)
        {
            GardenId = gardenId;
        }

        public GardenPlot(GardenPlotTemplate template)
            : this(template.Row, template.Column, template.SoilType)
        {
        }

        public GardenPlot(GardenPlotTemplate template, int gardenId)
            : this(template)
        {
            GardenId = gardenId;
        }

        public static IEnumerable<GardenPlot> FromTemplates(IEnumerable<GardenPlotTemplate> templates, int gardenId)
        {
            return templates.Select(x => new GardenPlot(x, gardenId));
        }
    }
}
