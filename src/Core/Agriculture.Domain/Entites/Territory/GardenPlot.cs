using Agriculture.Domain.Abstraction;
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

        public static IEnumerable<GardenPlot> HomeGardenPlots(int gardenId)
        {
            return [
                new GardenPlot(1, 1, "Loam"),
                new GardenPlot(1, 2, "Loam"),
                new GardenPlot(2, 1, "Sandy"),
                new GardenPlot(2, 2, "Clay")
                ];
        }
    }
}
