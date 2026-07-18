using Agriculture.Application.Features.Templates.GardenTemplates.GetAll;
using Agriculture.Application.Features.Templates.GardenTemplates.GetById;
using Agriculture.Application.Models.Results;
using Agriculture.Contract.DTOs.Templates.GardenTemplates;

namespace Agriculture.Application.Services.Templates
{
    public interface IGardenTemplateService
    {
        Task<Result<IEnumerable<GardenTemplateResponse>>> GetAllAsync(
            GetAllGardenTemplatesSpecification specification,
            CancellationToken cancellationToken);

        Task<Result<GardenTemplateResponse>> GetByIdAsync(
            GetGardenTemplateByIdSpecification specification,
            CancellationToken cancellationToken);
    }
}
