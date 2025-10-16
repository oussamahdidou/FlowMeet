using FlowMeet.Annuaire.Domain.Common;
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

        public async Task<List<TResult>> GetAsync<TResult>(QueryParameters<TypeEntite, TResult> queryParams) where TResult : class
        {
            IQueryable<TypeEntite> query = dbContext.TypeEntites.AsQueryable();

            if (queryParams.Filter != null)
                query = query.Where(x => x.Label.Contains(queryParams.Filter));


            if (!string.IsNullOrEmpty(queryParams.OrderBy))
            {
                query = queryParams.OrderByDescending
                    ? query.OrderByDescending(e => EF.Property<object>(e, queryParams.OrderBy))
                    : query.OrderBy(e => EF.Property<object>(e, queryParams.OrderBy));
            }

            if (queryParams.Skip.HasValue)
                query = query.Skip(queryParams.Skip.Value);
            if (queryParams.Take.HasValue)
                query = query.Take(queryParams.Take.Value);
            if (queryParams.Selector != null)
                return await query.Select(queryParams.Selector).ToListAsync();
            return await query.Cast<TResult>().ToListAsync();
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
