using FlowMeet.PlanningEngine.Application.Common.Interfaces;
using FlowMeet.PlanningEngine.Infrastructure.Data.DbContexts;

namespace FlowMeet.PlanningEngine.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlowMeetPlanningEngineDbContext dbcontext;
        public UnitOfWork(FlowMeetPlanningEngineDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task SaveChanges()
        {
            await dbcontext.SaveChangesAsync();
        }
    }
}
