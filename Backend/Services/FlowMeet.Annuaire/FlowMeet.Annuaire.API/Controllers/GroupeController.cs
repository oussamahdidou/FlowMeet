using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Features.Commands.Groupe;
using Microsoft.AspNetCore.Mvc;

namespace FlowMeet.Annuaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupeController : ControllerBase
    {
        private readonly IMediator mediator;
        public GroupeController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateGroupe/{entiteId}")]
        public async Task<IActionResult> CreateGroupe([FromRoute] string entiteId, [FromBody] CreateGroupeCommand command)
        {
            command.EntiteId = entiteId;
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpPost("AssignRolesToGroupe/{entiteId}")]
        public async Task<IActionResult> AssignRolesToGroupe([FromRoute] string entiteId, [FromBody] AssignRoleToGroupeCommand command)
        {
            command.EntiteId = entiteId;
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
    }
}
