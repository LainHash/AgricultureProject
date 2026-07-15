using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using MediatR;

namespace Agriculture.Application.Features.Catalog.PlantSpecicess.Commands.Create
{
    public record CreatePlantSpecicesCommand(CreatePlantSpecicesRequest Body)
        : IRequest<Result<PlantSpecicesResponse>>
    {
    }
}
