using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.Annuaire.Infrastructure.Data.DbContexts
{
    public class FlowMeetAnnuaireDbContext : DbContext
    {
        private readonly IEncryptionService encryptionService;
        public FlowMeetAnnuaireDbContext(DbContextOptions<FlowMeetAnnuaireDbContext> dbContextOptions, IEncryptionService encryptionService)
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
