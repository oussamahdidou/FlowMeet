using FlowMeet.Annuaire.Domain.Common;
using FlowMeet.Annuaire.Domain.Entities;
using FlowMeet.Annuaire.Domain.Repositories;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.Annuaire.Infrastructure.Repositories
{
    public class EntiteRepository : IEntiteRepository
    {
        private readonly FlowMeetAnnuaireDbContext dbContext;
        public EntiteRepository(FlowMeetAnnuaireDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(Entite entite)
        {
            await dbContext.Entites.AddAsync(entite);
        }

        public Task DeleteAsync(Entite entite)
        {
            dbContext.Entites.Remove(entite);
            return Task.CompletedTask;
        }

        public Task<List<Entite>> GetAllAsync(QueryParameters queryParams)
        {
            IQueryable<Entite> query = dbContext.Entites;
            // Apply filtering
            if (!string.IsNullOrEmpty(queryParams.Filter))
            {
                query = query.Where(e => e.Label.Contains(queryParams.Filter));
            }
            // Apply sorting
            if (!string.IsNullOrEmpty(queryParams.OrderBy))
            {
                query = queryParams.OrderByDescending
                    ? query.OrderByDescending(e => EF.Property<object>(e, queryParams.OrderBy))
                    : query.OrderBy(e => EF.Property<object>(e, queryParams.OrderBy));
            }
            // Apply pagination
            if (queryParams.Skip.HasValue)
            {
                query = query.Skip(queryParams.Skip.Value);
            }
            if (queryParams.Take.HasValue)
            {
                query = query.Take(queryParams.Take.Value);
            }
            return query.AsNoTracking().ToListAsync();
        }

        public async Task<Entite?> GetByIdAsync(string id)
        {
            return await dbContext.Entites.Include(x => x.TypeEntite).FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
