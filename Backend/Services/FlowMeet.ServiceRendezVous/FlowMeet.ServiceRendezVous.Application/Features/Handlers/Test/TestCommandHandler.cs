using Contracts.Events;
using FlowMeet.ServiceRendezVous.Application.Common;
using FlowMeet.ServiceRendezVous.Application.Common.Interfaces;
using FlowMeet.ServiceRendezVous.Application.Common.Requests;
using FlowMeet.ServiceRendezVous.Application.Features.Commands.Test;

namespace FlowMeet.ServiceRendezVous.Application.Features.Handlers.Test
{
    public class TestCommandHandler : IRequestHandler<TestCommand, Unit>
    {
        private readonly IPublisher<TestEvent> publisher;

        public TestCommandHandler(IPublisher<TestEvent> publisher)
        {
            this.publisher = publisher;
        }

        public async Task<Unit> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            await publisher.PublishAsync(new TestEvent(request.Message, Guid.NewGuid()));
            return Unit.Value;
        }
    }
}
