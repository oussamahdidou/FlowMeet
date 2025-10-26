using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Application.Features.Commands.TypeEntite;
using FlowMeet.Annuaire.Application.Features.DTOs.TypeEntite;
using FlowMeet.Annuaire.Application.Features.Queries.TypeEntite;
using FlowMeet.Annuaire.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace FlowMeet.Annuaire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeEntiteController : ControllerBase
    {
        private readonly IMediator mediator;
        public TypeEntiteController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("CreateTypeEntite")]
        public async Task<IActionResult> CreateTypeEntite([FromBody] CreateTypeEntiteCommand command)
        {
            Result<TypeEntiteDTO> result = await mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
        [HttpGet("GetAllTypeEntites")]
        public async Task<IActionResult> GetAllTypeEntites([FromQuery] GetAllTypeEntitiesQuery query)
        {
            Result<List<TypeEntiteDTO>> result = await mediator.Send(query);
            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

    }
}
