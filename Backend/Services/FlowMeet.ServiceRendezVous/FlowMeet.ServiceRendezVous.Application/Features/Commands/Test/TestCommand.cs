using FlowMeet.ServiceRendezVous.Application.Common;
using FlowMeet.ServiceRendezVous.Application.Common.Requests;

namespace FlowMeet.ServiceRendezVous.Application.Features.Commands.Test
{
    public class TestCommand : IRequest<Unit>
    {
        public string Message { get; set; }
    }
}
