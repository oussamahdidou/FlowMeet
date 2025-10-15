using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Domain.Repositories;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;

namespace FlowMeet.Annuaire.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlowMeetAnnuaireDbContext dbcontext;
        public ITypeEntiteRepository TypeEntites { get; }
        public UnitOfWork(FlowMeetAnnuaireDbContext dbcontext, ITypeEntiteRepository typeEntiteRepository)
        {
            this.dbcontext = dbcontext;
            this.TypeEntites = typeEntiteRepository;
        }
        public async Task SaveChanges()
        {
            await dbcontext.SaveChangesAsync();
        }
    }
}
