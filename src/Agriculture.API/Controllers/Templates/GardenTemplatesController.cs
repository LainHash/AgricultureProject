using Agriculture.Application.Features.Templates.GardenTemplates.Queries.GetAll;
using Agriculture.Application.Features.Templates.GardenTemplates.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.API.Controllers.Templates
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenTemplatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GardenTemplatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllGardenTemplatesQuery query,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var query = new GetGardenTemplateByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
