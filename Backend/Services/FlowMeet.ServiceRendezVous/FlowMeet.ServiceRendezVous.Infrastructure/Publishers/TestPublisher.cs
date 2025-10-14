using Contracts.Events;
using FlowMeet.ServiceRendezVous.Application.Common.Interfaces;
using KafkaFlow.Producers;

namespace FlowMeet.ServiceRendezVous.Infrastructure.Publishers
{
    public class TestPublisher : IPublisher<TestEvent>
    {
        private readonly IProducerAccessor producerAccessor;
        public TestPublisher(IProducerAccessor producerAccessor)
        {
            this.producerAccessor = producerAccessor;
        }
        public async Task PublishAsync(TestEvent @event)
        {
            var orderId = Guid.NewGuid().ToString();


            var producer = producerAccessor.GetProducer("producer-name");
            await producer.ProduceAsync(
                messageKey: orderId,
               @event
            );
        }
    }
}
