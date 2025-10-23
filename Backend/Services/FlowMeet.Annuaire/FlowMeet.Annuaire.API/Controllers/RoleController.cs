using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Features.Commands.Role;
using FlowMeet.Annuaire.Application.Features.DTOs.Responses.Role;
using FlowMeet.Annuaire.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace FlowMeet.Annuaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IMediator mediator;
        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateRole/{entiteId}")]
        public async Task<IActionResult> GetRolesByUserId([FromRoute] string entiteId, [FromBody] CreateRoleCommand command)
        {
            command.EntiteId = entiteId;
            Result<RoleDTO> result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
        [HttpPost("AdminCreateRole")]
        public async Task<IActionResult> AdminCreateRole([FromBody] AdminCreateRoleCommand command)
        {
            Result<RoleDTO> result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
    }
}
