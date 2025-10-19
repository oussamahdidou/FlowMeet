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

        public async Task<List<Entite>> GetAllAsync(QueryParameters queryParams)
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
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Entite?> GetByIdAsync(string id)
        {
            return await dbContext.Entites.Include(x => x.TypeEntite).FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Entite?> GetRootEntiteHiearchyAsync()
        {

            // 1️⃣ Fetch flat list from recursive CTE
            var flatEntites = await dbContext.Entites
                .FromSqlInterpolated($@"WITH RECURSIVE entite_tree AS (
    SELECT *
    FROM (
        SELECT *
        FROM ""Entites""
        WHERE ""ParentId"" IS NULL
        LIMIT 1
    ) AS root

    UNION ALL

    SELECT e.*
    FROM ""Entites"" e
    INNER JOIN entite_tree t ON e.""ParentId"" = t.""Id""
)
SELECT *
FROM entite_tree
WHERE NOT ""IsDeleted""
").Include(x => x.TypeEntite)
                .AsNoTracking()
                .ToListAsync();

            if (!flatEntites.Any())
                return null;

            // 2️⃣ Build tree
            var dict = flatEntites.ToDictionary(e => e.Id);

            Entite root = null;

            foreach (var ent in flatEntites)
            {
                if (ent.ParentId == null)
                {
                    root = ent;
                }
                else if (dict.TryGetValue(ent.ParentId, out var parent))
                {
                    parent.Enfants.Add(ent);
                }
            }

            return root;
        }
        public async Task<Entite?> GetEntiteHiearchyAsync(string id)
        {

            // 1️⃣ Fetch flat list from recursive CTE
            var flatEntites = await dbContext.Entites
                .FromSqlInterpolated($@"
                WITH RECURSIVE entite_tree AS (
                    SELECT *
                    FROM ""Entites""
                    WHERE ""Id"" = {id}

                    UNION ALL

                    SELECT e.*
                    FROM ""Entites"" e
                    INNER JOIN entite_tree t ON e.""ParentId"" = t.""Id""
                )
                SELECT *
                FROM entite_tree
                ORDER BY ""ParentId"" NULLS FIRST, ""Id""
            ").Include(x => x.TypeEntite)
                .AsNoTracking()
                .ToListAsync();

            if (!flatEntites.Any())
                return null;

            // 2️⃣ Build tree
            var dict = flatEntites.ToDictionary(e => e.Id);

            Entite root = null;

            foreach (var ent in flatEntites)
            {
                if (ent.Id == id)
                {
                    root = ent;
                }
                else if (dict.TryGetValue(ent.ParentId, out var parent))
                {
                    parent.Enfants.Add(ent);
                }
            }

            return root;
        }
    }
}



