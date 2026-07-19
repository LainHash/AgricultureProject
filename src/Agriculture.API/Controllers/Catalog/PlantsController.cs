using Agriculture.Application.Features.Catalog.Plants.Commands.Planting;
using Agriculture.Application.Features.Catalog.Plants.Queries.GetAll;
using Agriculture.Application.Features.Catalog.Plants.Queries.GetById;
using Agriculture.Contract.DTOs.Catalog.Plants;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Agriculture.API.Controllers.Catalog
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlantsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllPlantsQuery query,
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
            var query = new GetPlantByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("planting")]
        public async Task<IActionResult> Planting(
            [FromBody] PlantRequest body,
            CancellationToken cancellationToken)
        {
            var command = new PlantCommand(body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
