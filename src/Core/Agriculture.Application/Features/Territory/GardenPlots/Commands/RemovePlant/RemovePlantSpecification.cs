using Agriculture.Domain.Entites.Territory;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Territory.GardenPlots.Commands.RemovePlant
{
    public class RemovePlantSpecification
        : BaseSpecification<GardenPlot>
    {
        public RemovePlantSpecification(RemovePlantCommand command)
        {
            Criteria = gp => gp.PublicId == command.Id;

            AddInclude(x => x.Plant!);
        }
    }
}
