namespace FlowMeet.PlanningEngine.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}
