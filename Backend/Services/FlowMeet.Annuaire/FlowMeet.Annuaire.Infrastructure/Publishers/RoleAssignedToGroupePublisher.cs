using Contracts.Events.Groupe;
using Contracts.Helpers;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using KafkaFlow.Producers;

namespace FlowMeet.Annuaire.Infrastructure.Publishers
{
    public class RoleAssignedToGroupePublisher : IPublisher<RoleAssignedToGroupeEvent>
    {
        private readonly IProducerAccessor producerAccessor;
        public RoleAssignedToGroupePublisher(IProducerAccessor producerAccessor)
        {
            this.producerAccessor = producerAccessor;
        }
        public async Task PublishAsync(RoleAssignedToGroupeEvent @event)
        {
            var orderId = Guid.NewGuid().ToString();
            var producer = producerAccessor.GetProducer(KafkaProducers.RoleAssignedToGroupProducer.ToString());
            await producer.ProduceAsync(
                messageKey: orderId,
               @event
            );
        }
    }
}
