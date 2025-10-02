using FlowMeet.Notification.Application.Common.Interfaces;
using FlowMeet.Notification.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.Notification.Infrastructure.Data.DbContexts
{
    public class FlowMeetNotificationDbContext : DbContext
    {
        private readonly IEncryptionService encryptionService;
        public FlowMeetNotificationDbContext(DbContextOptions<FlowMeetNotificationDbContext> dbContextOptions, IEncryptionService encryptionService)
        : base(dbContextOptions)
        {
            this.encryptionService = encryptionService;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseEncryptedProperties(encryptionService);
        }
    }
}
