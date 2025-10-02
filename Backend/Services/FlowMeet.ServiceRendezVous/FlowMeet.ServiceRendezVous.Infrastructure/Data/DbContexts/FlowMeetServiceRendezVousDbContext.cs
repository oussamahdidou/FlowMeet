using FlowMeet.ServiceRendezVous.Application.Common.Interfaces;
using FlowMeet.ServiceRendezVous.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.ServiceRendezVous.Infrastructure.Data.DbContexts
{
    public class FlowMeetServiceRendezVousDbContext : DbContext
    {
        private readonly IEncryptionService encryptionService;
        public FlowMeetServiceRendezVousDbContext(DbContextOptions<FlowMeetServiceRendezVousDbContext> dbContextOptions, IEncryptionService encryptionService)
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
