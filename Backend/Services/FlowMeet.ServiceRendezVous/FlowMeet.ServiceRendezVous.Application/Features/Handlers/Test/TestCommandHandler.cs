using FlowMeet.ServiceRendezVous.Application.Common;
using FlowMeet.ServiceRendezVous.Application.Common.Requests;
using FlowMeet.ServiceRendezVous.Application.Features.Commands.Test;

namespace FlowMeet.ServiceRendezVous.Application.Features.Handlers.Test
{
    public class TestCommandHandler : IRequestHandler<TestCommand, Unit>
    {



        public async Task<Unit> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            await Task.Delay(10, cancellationToken);
            return Unit.Value;
        }
    }
}
