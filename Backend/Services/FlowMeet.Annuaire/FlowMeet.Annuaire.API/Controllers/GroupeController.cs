using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Features.Commands.Groupe;
using FlowMeet.Annuaire.Application.Features.Queries.Groupe;
using FlowMeet.Annuaire.Domain.Common;
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
        [HttpDelete("RemoveRolesFromGroupe/{entiteId}")]
        public async Task<IActionResult> RemoveRolesFromGroupe([FromRoute] string entiteId, [FromBody] RemoveRoleFromGroupeCommand command)
        {
            command.EntiteId = entiteId;
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);

        }
        [HttpPost("AdminCreateGroupe")]
        public async Task<IActionResult> AdminCreateGroupe([FromBody] AdminCreateGroupeCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpPost("AdminAssignRolesToGroupe")]
        public async Task<IActionResult> AdminAssignRolesToGroupe([FromBody] AdminAssignRoleToGroupeCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpDelete("AdminRemoveRolesFromGroupe")]
        public async Task<IActionResult> AdminRemoveRolesFromGroupe([FromBody] AdminRemoveRoleFromGroupeCommand command)
        {
            var result = await mediator.Send(command);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpGet("GetAllGroupes")]
        public async Task<IActionResult> GetAllGroupes([FromQuery] GetAllGroupesQuery query)
        {
            var result = await mediator.Send(query);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
        [HttpGet("GetEntiteGroupes/{entiteId}")]
        public async Task<IActionResult> GetEntiteGroupes([FromRoute] string entiteId, [FromQuery] QueryParameters query)
        {
            var getEntiteGroupesQuery = new GetEntiteGroupeQuery
            {
                EntiteId = entiteId,
                Parameters = new QueryParameters
                {
                    Filter = query.Filter,
                    OrderBy = query.OrderBy,
                    OrderByDescending = query.OrderByDescending,
                    Skip = query.Skip,
                    Take = query.Take
                }
            };
            var result = await mediator.Send(getEntiteGroupesQuery);
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return BadRequest(result.Error);
        }
    }
}
