using Contracts.Events.Collaborateur;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using KafkaFlow.Producers;

namespace FlowMeet.Annuaire.Infrastructure.Publishers
{
    public class GroupeRemovedFromCollaborateurPublisher : IPublisher<GroupeRemovedFromCollaborateurEvent>
    {
        private readonly IProducerAccessor producerAccessor;
        public GroupeRemovedFromCollaborateurPublisher(IProducerAccessor producerAccessor)
        {
            this.producerAccessor = producerAccessor;
        }
        public async Task PublishAsync(GroupeRemovedFromCollaborateurEvent @event)
        {
            var orderId = Guid.NewGuid().ToString();
            var producer = producerAccessor.GetProducer<GroupeRemovedFromCollaborateurEvent>();
            await producer.ProduceAsync(orderId, @event);
        }
    }
}
