using Contracts.Events.Collaborateur;
using Contracts.Helpers;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using KafkaFlow.Producers;

namespace FlowMeet.Annuaire.Infrastructure.Publishers
{
    public class RoleAssignedToCollaborateurProducer : IPublisher<RoleAssignedToCollaborateurEvent>
    {
        private readonly IProducerAccessor producerAccessor;
        public RoleAssignedToCollaborateurProducer(IProducerAccessor producerAccessor)
        {
            this.producerAccessor = producerAccessor;
        }
        public async Task PublishAsync(RoleAssignedToCollaborateurEvent @event)
        {
            var orderId = Guid.NewGuid().ToString();
            var producer = producerAccessor.GetProducer(KafkaProducers.RoleAssignedToCollaborateurProducer.ToString());
            await producer.ProduceAsync(orderId, @event);
        }
    }
}
