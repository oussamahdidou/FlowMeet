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
        public UnitOfWork(FlowMeetAnnuaireDbContext dbcontext, ITypeEntiteRepository typeEntiteRepository, IEntiteRepository entites, IRoleRepository roles, IGroupeRepository groupes)
        {
            this.dbcontext = dbcontext;
            TypeEntites = typeEntiteRepository;
            Entites = entites;
            Roles = roles;
            Groupes = groupes;
        }
        public async Task SaveChanges()
        {
            await dbcontext.SaveChangesAsync();
        }
    }
}
