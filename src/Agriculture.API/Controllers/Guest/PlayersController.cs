using Agriculture.Application.Features.Guest.Players.Queries.GetAll;
using Agriculture.Application.Features.Guest.Players.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.API.Controllers.Guest
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] GetAllPlayersQuery query,
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
            var query = new GetPlayerByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
