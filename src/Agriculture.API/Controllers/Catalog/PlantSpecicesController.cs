using Agriculture.Application.Features.Catalog.PlantSpecicess.Commands.Create;
using Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetAll;
using Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetById;
using Agriculture.Contract.DTOs.Catalog.PlantSpecices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Agriculture.API.Controllers.Catalog
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantSpecicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlantSpecicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllPlantSpecicesQuery query,
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
            var query = new GetPlantSpecicesByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreatePlantSpecicesRequest body,
            CancellationToken cancellationToken)
        {
            var command = new CreatePlantSpecicesCommand(body);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
