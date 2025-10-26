using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Features.Commands.Role;
using FlowMeet.Annuaire.Application.Features.DTOs.Role;
using FlowMeet.Annuaire.Application.Features.Queries.Role;
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
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetAllRolesQuery query)
        {
            Result<List<RoleDTO>> result = await mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
        [HttpGet("GetEntiteRoles/{entiteId}")]
        public async Task<IActionResult> GetEntiteRoles([FromRoute] string entiteId, [FromQuery] QueryParameters query)
        {
            GetEntiteRolesQuery getEntiteRolesQuery = new GetEntiteRolesQuery
            {
                EntiteId = entiteId,
                Params = query
            };
            Result<List<RoleDTO>> result = await mediator.Send(getEntiteRolesQuery);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
    }
}
