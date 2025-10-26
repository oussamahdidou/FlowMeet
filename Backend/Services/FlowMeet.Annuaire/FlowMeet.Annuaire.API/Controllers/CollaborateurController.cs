using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Features.Commands.Collaborateur;
using Microsoft.AspNetCore.Mvc;

namespace FlowMeet.Annuaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaborateurController : ControllerBase
    {
        private readonly IMediator mediator;
        public CollaborateurController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateCollaborateur/{entityId}")]
        public async Task<IActionResult> CreateCollaborateur([FromRoute] string entityId, [FromBody] CreateCollaborateurCommand command)
        {
            command.EntiteId = entityId;
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
    }
}
