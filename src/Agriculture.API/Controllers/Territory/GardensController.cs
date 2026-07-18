using Agriculture.Application.Features.Territory.Gardens.Commands.AddPlot;
using Agriculture.Application.Features.Territory.Gardens.Queries.GetAll;
using Agriculture.Application.Features.Territory.Gardens.Queries.GetById;
using Agriculture.Contract.DTOs.Territory.GardenPlots;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.API.Controllers.Territory
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardensController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GardensController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllGardensQuery query,
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
            var query = new GetGardenByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("{id}/add-plots")]
        public async Task<IActionResult> AddPlot(
            [FromRoute] Guid id,
            [FromBody] IEnumerable<AddGardenPlotRequest> body,
            CancellationToken cancellationToken)
        {
            var command = new AddGardenPlotsCommand(id, body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
