using Contracts.Events.Collaborateur;
using Contracts.Helpers;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using KafkaFlow.Producers;

namespace FlowMeet.Annuaire.Infrastructure.Publishers
{
    public class GroupeAssignedToCollaborateurProducer : IPublisher<GroupeAssignedToCollaborateurEvent>
    {
        private readonly IProducerAccessor producerAccessor;
        public GroupeAssignedToCollaborateurProducer(IProducerAccessor producerAccessor)
        {
            this.producerAccessor = producerAccessor;
        }
        public async Task PublishAsync(GroupeAssignedToCollaborateurEvent @event)
        {
            var orderId = Guid.NewGuid().ToString();
            var producer = producerAccessor.GetProducer(KafkaProducers.GroupeAssignedToCollaborateurProducer.ToString());
            await producer.ProduceAsync(orderId, @event);
        }
    }
}
