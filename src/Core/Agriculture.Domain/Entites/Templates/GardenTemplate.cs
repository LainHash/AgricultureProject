using Agriculture.Domain.Abstraction;

namespace Agriculture.Domain.Entites.Templates
{
    public class GardenTemplate : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public string UnlockType { get; private set; } = string.Empty;
        public decimal UnlockValue { get; private set; }
        public decimal UnlockPrice { get; private set; }

        public int? ReferenceId { get; private set; }

        public ICollection<GardenPlotTemplate> GardenPlotTemplates { get; private set; } = [];
    }
}
