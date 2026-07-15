using Agriculture.Application.Features.Catalog.PlantSpecicess.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
