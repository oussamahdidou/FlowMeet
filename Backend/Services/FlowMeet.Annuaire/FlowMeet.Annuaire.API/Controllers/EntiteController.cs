using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Features.Commands.Entite;
using FlowMeet.Annuaire.Application.Features.Queries.TypeEntite;
using Microsoft.AspNetCore.Mvc;

namespace FlowMeet.Annuaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntiteController : ControllerBase
    {
        private readonly IMediator mediator;
        public EntiteController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateEntite")]
        public async Task<IActionResult> CreateEntite([FromBody] CreateEntiteCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpGet("GetEntiteHiearchie/{entiteId}")]
        public async Task<IActionResult> GetEntiteHiearchie([FromRoute] string entiteId)
        {
            var query = new GetEntiteHiearchieQuery
            {
                EntiteId = entiteId
            };
            var result = await mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpGet("GetRootEntiteHiearchie")]
        public async Task<IActionResult> GetRootEntiteHiearchie()
        {
            var query = new GetRootEntiteHiearchieQuery();
            var result = await mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }

    }
}
