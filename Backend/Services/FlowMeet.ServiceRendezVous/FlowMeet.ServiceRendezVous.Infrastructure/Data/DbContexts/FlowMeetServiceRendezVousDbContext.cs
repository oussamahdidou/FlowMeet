using FlowMeet.ServiceRendezVous.Application.Common.Interfaces;
using FlowMeet.ServiceRendezVous.Domain.Entities;
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
        public DbSet<RendezVous> RendezVous { get; set; }
        public DbSet<RendezVousType> RendezVousTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Collaborateur> Collaborateurs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<RoleRendezVousType> RoleRendezVousTypes { get; set; }
        public DbSet<GroupeRendezVousType> GroupeRendezVousTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseEncryptedProperties(encryptionService);

            modelBuilder.Entity<RoleRendezVousType>(x => x.HasKey(p => new { p.RoleId, p.RendezVousTypeId }));
            modelBuilder.Entity<RoleRendezVousType>()
            .HasOne(u => u.Role)
            .WithMany(u => u.RoleRendezVousTypes)
            .HasForeignKey(p => p.RoleId);
            modelBuilder.Entity<RoleRendezVousType>()
            .HasOne(u => u.RendezVousType)
            .WithMany(u => u.RoleRendezVousTypes)
            .HasForeignKey(p => p.RendezVousTypeId);
            ////////////////////////////////////////////
            modelBuilder.Entity<GroupeRendezVousType>(x => x.HasKey(p => new { p.GroupeId, p.RendezVousTypeId }));
            modelBuilder.Entity<GroupeRendezVousType>()
            .HasOne(u => u.Groupe)
            .WithMany(u => u.GroupeRendezVousTypes)
            .HasForeignKey(p => p.GroupeId);
            modelBuilder.Entity<GroupeRendezVousType>()
            .HasOne(u => u.RendezVousType)
            .WithMany(u => u.GroupeRendezVousTypes)
            .HasForeignKey(p => p.RendezVousTypeId);
            ///////////////////////////////////////////

        }
    }
}
