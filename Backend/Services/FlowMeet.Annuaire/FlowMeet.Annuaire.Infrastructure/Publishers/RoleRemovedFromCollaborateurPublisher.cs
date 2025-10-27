using Contracts.Events.Collaborateur;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using KafkaFlow.Producers;

namespace FlowMeet.Annuaire.Infrastructure.Publishers
{
    public class RoleRemovedFromCollaborateurPublisher : IPublisher<RoleRemovedFromCollaborateurEvent>
    {
        private readonly IProducerAccessor producerAccessor;
        public RoleRemovedFromCollaborateurPublisher(IProducerAccessor producerAccessor)
        {
            this.producerAccessor = producerAccessor;
        }
        public async Task PublishAsync(RoleRemovedFromCollaborateurEvent @event)
        {
            var orderId = Guid.NewGuid().ToString();
            var producer = producerAccessor.GetProducer<RoleRemovedFromCollaborateurEvent>();
            await producer.ProduceAsync(orderId, @event);
        }
    }
}
