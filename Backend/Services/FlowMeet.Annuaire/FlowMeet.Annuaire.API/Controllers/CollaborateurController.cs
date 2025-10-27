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
        [HttpPost("AssignRoleToCollaborateur/{entiteId}")]
        public async Task<IActionResult> AssignRoleToCollaborateur([FromRoute] string entiteId, [FromBody] AssignRoleToCollaborateurCommand command)
        {
            command.EntiteId = entiteId;
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpPost("RemoveRoleFromCollaborateur/{entiteId}")]
        public async Task<IActionResult> RemoveRoleFromCollaborateur([FromRoute] string entiteId, [FromBody] RemoveRoleFromCollaborateurCommand command)
        {
            command.EntiteId = entiteId;
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpPost("AdminAssignRoleToCollaborateur")]
        public async Task<IActionResult> AdminAssignRoleToCollaborateur([FromBody] AdminAssignRoleToCollaborateurCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpPost("AdminRemoveRoleFromCollaborateur")]
        public async Task<IActionResult> AdminRemoveRoleFromCollaborateur([FromBody] AdminRemoveRoleFromCollaborateurCommand command)
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
