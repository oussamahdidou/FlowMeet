using FlowMeet.Notification.Application.Common.Interfaces;
using FlowMeet.Notification.Domain.Entities;
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
        public DbSet<NotificationTemplate> NotificationTemplates { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<TargetUser> TargetUsers { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseEncryptedProperties(encryptionService);
            modelBuilder.Entity<UserNotification>(x => x.HasKey(p => new { p.TargetUserId, p.MessageId }));
            modelBuilder.Entity<UserNotification>()
            .HasOne(u => u.TargetUser)
            .WithMany(u => u.UserNotifications)
            .HasForeignKey(p => p.TargetUserId);
            modelBuilder.Entity<UserNotification>()
            .HasOne(u => u.Message)
            .WithMany(u => u.UserNotifications)
            .HasForeignKey(p => p.MessageId);
        }
    }
}
