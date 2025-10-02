using FlowMeet.Annuaire.Application.Common.Interfaces;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;

namespace FlowMeet.Annuaire.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlowMeetAnnuaireDbContext dbcontext;
        public UnitOfWork(FlowMeetAnnuaireDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task SaveChanges()
        {
            await dbcontext.SaveChangesAsync();
        }
    }
}
