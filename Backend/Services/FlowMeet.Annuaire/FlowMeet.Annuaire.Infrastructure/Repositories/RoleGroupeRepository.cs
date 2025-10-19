using FlowMeet.Annuaire.Domain.Entities;
using FlowMeet.Annuaire.Domain.Repositories;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;

namespace FlowMeet.Annuaire.Infrastructure.Repositories
{
    public class RoleGroupeRepository : IRoleGroupeRepository
    {
        private readonly FlowMeetAnnuaireDbContext dbContext;
        public RoleGroupeRepository(FlowMeetAnnuaireDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(RoleGroupe roleGroupe)
        {
            await dbContext.RoleGroupes.AddAsync(roleGroupe);
        }

        public Task DeleteAsync(RoleGroupe roleGroupe)
        {
            throw new NotImplementedException();
        }
    }
}
