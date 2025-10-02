using FlowMeet.PlanningEngine.Application.Common.Interfaces;
using FlowMeet.PlanningEngine.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.PlanningEngine.Infrastructure.Data.DbContexts
{
    public class FlowMeetPlanningEngineDbContext : DbContext
    {
        private readonly IEncryptionService encryptionService;
        public FlowMeetPlanningEngineDbContext(DbContextOptions<FlowMeetPlanningEngineDbContext> dbContextOptions, IEncryptionService encryptionService)
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
