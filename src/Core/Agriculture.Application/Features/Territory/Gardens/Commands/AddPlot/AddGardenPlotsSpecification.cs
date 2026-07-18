using Agriculture.Contract.DTOs.Territory.GardenPlots;
using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Territory.Gardens.Commands.AddPlot
{
    public class AddGardenPlotsSpecification
        : BaseSpecification<Garden>
    {
        public Guid GardenId { get; private set; }
        public IEnumerable<AddGardenPlotRequest> Body { get; private set; }
        public AddGardenPlotsSpecification(AddGardenPlotsCommand command)
        {
            GardenId = command.GardenId;
            Body = command.Body;

            AddInclude(x => x.GardenPlots);

            EnableSoftDeleteFilter();
        }

        public void ApplyCriteria(int id)
        {
            Criteria = g => g.Id == id;
        }
    }
}
