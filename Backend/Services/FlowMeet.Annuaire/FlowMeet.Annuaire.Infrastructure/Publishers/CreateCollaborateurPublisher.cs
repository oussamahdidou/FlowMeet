using Contracts.Events.Collaborateur;
using Contracts.Helpers;
using FlowMeet.Annuaire.Application.Common.Interfaces;
using KafkaFlow.Producers;

namespace FlowMeet.Annuaire.Infrastructure.Publishers
{
    public class CreateCollaborateurPublisher : IPublisher<CreateCollaborateurEvent>
    {
        private readonly IProducerAccessor producerAccessor;
        public CreateCollaborateurPublisher(IProducerAccessor producerAccessor)
        {
            this.producerAccessor = producerAccessor;
        }
        public async Task PublishAsync(CreateCollaborateurEvent @event)
        {
            var orderId = Guid.NewGuid().ToString();
            var producer = producerAccessor.GetProducer(KafkaProducers.CollaborateurCreatedProducer.ToString());
            await producer.ProduceAsync(orderId, @event);
        }
    }
}
