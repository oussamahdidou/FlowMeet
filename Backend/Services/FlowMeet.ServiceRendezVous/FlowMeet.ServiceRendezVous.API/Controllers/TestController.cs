using FlowMeet.ServiceRendezVous.Application.Common.Interfaces;
using FlowMeet.ServiceRendezVous.Application.Features.Commands.Test;
using FlowMeet.ServiceRendezVous.Application.Features.DTOs.Requests.Test;
using Microsoft.AspNetCore.Mvc;

namespace FlowMeet.ServiceRendezVous.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<TestController> _logger;
        public TestController(
            IMediator mediator,
            ILogger<TestController> logger)
        {
            this.mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] TestDTO testDTO)
        {

            await mediator.Send(new TestCommand { Message = testDTO.Message });

            _logger.LogInformation("Test created and published: ");

            return Ok(new { Message = "Test created successfully" });
        }
    }
}
