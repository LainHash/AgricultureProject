using Agriculture.Application.Features.Catalog.Plants.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
