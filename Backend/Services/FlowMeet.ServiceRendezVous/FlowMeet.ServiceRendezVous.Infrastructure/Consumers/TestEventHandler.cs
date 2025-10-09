using Contracts.Events;
using KafkaFlow;

namespace FlowMeet.ServiceRendezVous.Infrastructure.Consumers
{
    public class TestEventHandler : IMessageHandler<TestEvent>
    {
        public Task Handle(IMessageContext context, TestEvent message)
        {
            Console.WriteLine($"Received message with Guid: {message.Guid}");
            return Task.CompletedTask;
        }
    }
}
