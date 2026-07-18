using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Templates.GardenTemplates;
using MediatR;

namespace Agriculture.Application.Features.Templates.GardenTemplates.GetById
{
    public record GetGardenTemplateByIdQuery(Guid Id)
        : IRequest<Result<GardenTemplateResponse>>
    {
    }
}
