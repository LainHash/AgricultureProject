using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using Agriculture.Domain.Entites.Catalog;
using Agriculture.Domain.Specifications;

namespace Agriculture.Application.Features.Catalog.PlantSpecicess.Commands.Create
{
    public class CreatePlantSpecicesSpecification
        : BaseSpecification<PlantSpecices>
    {
        public CreatePlantSpecicesRequest Body { get; set; }
        public CreatePlantSpecicesSpecification(CreatePlantSpecicesCommand command)
        {
            Body = command.Body;
            AddInclude(x => x.Category);
        }

        public void ApplyCriteria(int id)
        {
            Criteria = ps => ps.Id == id;
        }
    }
}
