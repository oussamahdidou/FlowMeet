namespace FlowMeet.Annuaire.Application.Common.Interfaces
{
    public interface IPublisher<TEvent> where TEvent : class
    {
        Task PublishAsync(TEvent @event);
    }
}
