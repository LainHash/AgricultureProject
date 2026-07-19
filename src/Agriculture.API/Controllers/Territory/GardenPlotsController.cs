using Agriculture.Application.Features.Territory.GardenPlots.Commands.Planting;
using Agriculture.Application.Features.Territory.GardenPlots.Commands.RemovePlant;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.API.Controllers.Territory
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenPlotsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GardenPlotsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{plotId}/plant")]
        public async Task<IActionResult> Plant(
            [FromRoute] Guid plotId,
            [FromBody] Guid specicesId,
            CancellationToken cancellationToken)
        {
            var command = new PlantingCommand(plotId, specicesId);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPatch("{id}/remove-plant")]
        public async Task<IActionResult> RemovePlant(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            var command = new RemovePlantCommand(id);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
