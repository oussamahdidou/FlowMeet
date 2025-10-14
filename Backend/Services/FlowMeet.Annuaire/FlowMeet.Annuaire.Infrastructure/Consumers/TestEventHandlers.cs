using Contracts.Events;
using KafkaFlow;
using Microsoft.Extensions.Logging;

namespace FlowMeet.Annuaire.Infrastructure.Consumers
{
    public class TestEventHandler : IMessageHandler<TestEvent>
    {
        private readonly ILogger<TestEventHandler> logger;
        public TestEventHandler(ILogger<TestEventHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(IMessageContext context, TestEvent message)
        {
            logger.LogInformation(
                "Processing Message: {message}",
                message.ToString()
            );




            return Task.CompletedTask;
        }
    }
}
