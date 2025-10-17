using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Features.Commands.Entite;
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

    }
}
