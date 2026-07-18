using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Templates.GardenTemplates;
using MediatR;

namespace Agriculture.Application.Features.Templates.GardenTemplates.GetAll
{
    public record GetAllGardenTemplatesQuery
        : IRequest<Result<IEnumerable<GardenTemplateResponse>>>
    {
    }
}
