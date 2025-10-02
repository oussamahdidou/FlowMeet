namespace FlowMeet.Notification.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
