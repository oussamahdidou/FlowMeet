namespace FlowMeet.Annuaire.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
