using FlowMeet.Annuaire.Domain.Entities;
using FlowMeet.Annuaire.Domain.Repositories;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.Annuaire.Infrastructure.Repositories
{
    public class TypeEntiteRepository : ITypeEntiteRepository
    {
        private readonly FlowMeetAnnuaireDbContext dbContext;
        public TypeEntiteRepository(FlowMeetAnnuaireDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(TypeEntite typeEntite)
        {
            await dbContext.TypeEntites.AddAsync(typeEntite);
        }

        public Task DeleteAsync(TypeEntite typeEntite)
        {
            dbContext.TypeEntites.Remove(typeEntite);
            return Task.CompletedTask;
        }

        public async Task<TypeEntite?> GetByIdAsync(string id)
        {
            return await dbContext.TypeEntites.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> IsLevelExistAsync(int level)
        {
            return await dbContext.TypeEntites.AnyAsync(x => x.Level == level);
        }


    }
}
