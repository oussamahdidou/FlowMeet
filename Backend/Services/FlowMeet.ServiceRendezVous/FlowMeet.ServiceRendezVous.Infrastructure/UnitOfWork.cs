using FlowMeet.ServiceRendezVous.Application.Common.Interfaces;
using FlowMeet.ServiceRendezVous.Infrastructure.Data.DbContexts;

namespace FlowMeet.ServiceRendezVous.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlowMeetServiceRendezVousDbContext dbContext;
        public UnitOfWork(FlowMeetServiceRendezVousDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
