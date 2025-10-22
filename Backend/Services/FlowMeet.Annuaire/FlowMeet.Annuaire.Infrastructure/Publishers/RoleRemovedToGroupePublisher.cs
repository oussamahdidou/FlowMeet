using Contracts.Events.Groupe;
using Contracts.Helpers;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using KafkaFlow.Producers;

namespace FlowMeet.Annuaire.Infrastructure.Publishers
{
    public class RoleRemovedToGroupePublisher : IPublisher<RoleRemovedFromGroupeEvent>
    {
        private readonly IProducerAccessor producerAccessor;
        public RoleRemovedToGroupePublisher(IProducerAccessor producerAccessor)
        {
            this.producerAccessor = producerAccessor;
        }
        public async Task PublishAsync(RoleRemovedFromGroupeEvent @event)
        {
            var orderId = Guid.NewGuid().ToString();
            var producer = producerAccessor.GetProducer(KafkaProducers.RoleRemovedFromGroupProducer.ToString());
            await producer.ProduceAsync(
                messageKey: orderId,
               @event
            );
        }
    }
}
