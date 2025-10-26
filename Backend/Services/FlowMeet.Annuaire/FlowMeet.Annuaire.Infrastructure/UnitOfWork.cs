using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Domain.Repositories;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;

namespace FlowMeet.Annuaire.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlowMeetAnnuaireDbContext dbcontext;
        public ITypeEntiteRepository TypeEntites { get; }
        public IEntiteRepository Entites { get; }
        public IRoleRepository Roles { get; }
        public IGroupeRepository Groupes { get; }
        public ICollaborateurRepository Collaborateurs { get; }
        public IRoleGroupeRepository GroupeRoles { get; }

        public UnitOfWork(FlowMeetAnnuaireDbContext dbcontext, ITypeEntiteRepository typeEntiteRepository, IEntiteRepository entites, IRoleRepository roles, IGroupeRepository groupes, IRoleGroupeRepository groupeRoles, ICollaborateurRepository collaborateurs)
        {
            this.dbcontext = dbcontext;
            TypeEntites = typeEntiteRepository;
            Entites = entites;
            Roles = roles;
            Groupes = groupes;
            GroupeRoles = groupeRoles;
            Collaborateurs = collaborateurs;
        }
        public async Task SaveChanges()
        {
            await dbcontext.SaveChangesAsync();
        }
    }
}
