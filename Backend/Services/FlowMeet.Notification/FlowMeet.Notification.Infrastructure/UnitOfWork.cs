using FlowMeet.Notification.Application.Common.Interfaces;
using FlowMeet.Notification.Infrastructure.Data.DbContexts;

namespace FlowMeet.Notification.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlowMeetNotificationDbContext dbcontext;
        public UnitOfWork(FlowMeetNotificationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task SaveChanges()
        {
            await dbcontext.SaveChangesAsync();
        }
    }
}
