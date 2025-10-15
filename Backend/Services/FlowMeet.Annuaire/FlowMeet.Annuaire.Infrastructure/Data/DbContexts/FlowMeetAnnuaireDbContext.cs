using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Domain.Entities;
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
        public DbSet<Collaborateur> Collaborateurs { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<CollaborateurRole> CollaborateurRoles { get; set; }
        public DbSet<CollaborateurGroupe> CollaborateurGroupes { get; set; }
        public DbSet<RoleGroupe> RoleGroupes { get; set; }
        public DbSet<TypeEntite> TypeEntites { get; set; }
        public DbSet<Entite> Entites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseEncryptedProperties(encryptionService);
            modelBuilder.Entity<CollaborateurRole>(x => x.HasKey(p => new { p.RoleId, p.CollaborateurId }));
            modelBuilder.Entity<CollaborateurRole>()
            .HasOne(u => u.Role)
            .WithMany(u => u.CollaborateurRoles)
            .HasForeignKey(p => p.RoleId);
            modelBuilder.Entity<CollaborateurRole>()
            .HasOne(u => u.Collaborateur)
            .WithMany(u => u.CollaborateurRoles)
            .HasForeignKey(p => p.CollaborateurId);
            modelBuilder.Entity<CollaborateurGroupe>(x => x.HasKey(p => new { p.GroupeId, p.CollaborateurId }));
            modelBuilder.Entity<CollaborateurGroupe>()
            .HasOne(u => u.Groupe)
            .WithMany(u => u.CollaborateurGroupes)
            .HasForeignKey(p => p.GroupeId);
            modelBuilder.Entity<CollaborateurGroupe>()
            .HasOne(u => u.Collaborateur)
            .WithMany(u => u.CollaborateurGroupes)
            .HasForeignKey(p => p.CollaborateurId);
            modelBuilder.Entity<RoleGroupe>(x => x.HasKey(p => new { p.RoleId, p.GroupeId }));
            modelBuilder.Entity<RoleGroupe>()
                .HasOne(u => u.Role)
                .WithMany(u => u.RoleGroupes)
                .HasForeignKey(p => p.RoleId);
            modelBuilder.Entity<RoleGroupe>()
                .HasOne(u => u.Groupe)
                .WithMany(u => u.RoleGroupes)
                .HasForeignKey(p => p.GroupeId);
        }
    }
}
