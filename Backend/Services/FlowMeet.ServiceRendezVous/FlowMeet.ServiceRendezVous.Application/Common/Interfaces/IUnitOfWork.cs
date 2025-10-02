namespace FlowMeet.ServiceRendezVous.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
