using Contracts.Events.Role;
using Contracts.Helpers;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using KafkaFlow.Producers;

namespace FlowMeet.Annuaire.Infrastructure.Publishers
{
    public class RoleCreatedPublisher : IPublisher<RoleCreatedEvent>
    {
        private readonly IProducerAccessor producerAccessor;
        public RoleCreatedPublisher(IProducerAccessor producerAccessor)
        {
            this.producerAccessor = producerAccessor;
        }
        public async Task PublishAsync(RoleCreatedEvent @event)
        {
            var orderId = Guid.NewGuid().ToString();


            var producer = producerAccessor.GetProducer(KafkaProducers.RoleCreatedProducer.ToString());
            await producer.ProduceAsync(
                messageKey: orderId,
               @event
            );
        }
    }
}
