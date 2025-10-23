using FlowMeet.Annuaire.Domain.Common;
using FlowMeet.Annuaire.Domain.Entities;
using FlowMeet.Annuaire.Domain.Repositories;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.Annuaire.Infrastructure.Repositories
{
    public class GroupeRepository : IGroupeRepository
    {
        private readonly FlowMeetAnnuaireDbContext dbContext;

        public GroupeRepository(FlowMeetAnnuaireDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(Groupe groupe)
        {
            await dbContext.Groupes.AddAsync(groupe);
        }

        public Task<List<Groupe>> GetAllAsync(QueryParameters queryParameters)
        {
            IQueryable<Groupe> query = dbContext.Groupes;
            // Apply filtering, sorting, and pagination based on queryParameters
            if (!string.IsNullOrEmpty(queryParameters.Filter))
            {
                query = query.Where(g => g.Label.Contains(queryParameters.Filter));
            }
            if (!string.IsNullOrEmpty(queryParameters.OrderBy))
            {
                if (queryParameters.OrderByDescending)
                {
                    query = query.OrderByDescending(g => EF.Property<object>(g, queryParameters.OrderBy));
                }
                else
                {
                    query = query.OrderBy(g => EF.Property<object>(g, queryParameters.OrderBy));
                }
            }
            if (queryParameters.Skip.HasValue)
            {
                query = query.Skip(queryParameters.Skip.Value);
            }
            if (queryParameters.Take.HasValue)
            {
                query = query.Take(queryParameters.Take.Value);
            }
            return query.AsNoTracking().ToListAsync();

        }

        public Task<Groupe?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GroupeExistsInEntiteAsync(string groupeId, string entiteId)
        {
            return await dbContext.Groupes.AnyAsync(g => g.Id == groupeId && g.EntiteId == entiteId);
        }

        public async Task<List<Groupe>> GroupeExistsInEntityOrParentsAsync(string entiteId, QueryParameters parameters)
        {
            var query = dbContext.Groupes
                .FromSqlInterpolated($@"
                WITH RECURSIVE entite_hierarchy AS (
                    SELECT ""Id"", ""ParentId""
                    FROM ""Entites""
                    WHERE ""Id"" = {entiteId}

                    UNION ALL

                    SELECT e.""Id"", e.""ParentId""
                    FROM ""Entites"" e
                    INNER JOIN entite_hierarchy eh ON e.""Id"" = eh.""ParentId""
                )
                SELECT r.*
                FROM ""Groupes"" r
                INNER JOIN entite_hierarchy eh ON r.""EntiteId"" = eh.""Id""
                WHERE r.""IsDeleted"" = FALSE
                  AND (r.""EntiteId"" = {entiteId} OR r.""Heritee"" = TRUE)
            ");
            // Apply filtering
            if (!string.IsNullOrEmpty(parameters.Filter))
            {
                query = query.Where(g => g.Label.Contains(parameters.Filter));
            }
            // Apply sorting
            if (!string.IsNullOrEmpty(parameters.OrderBy))
            {
                query = parameters.OrderByDescending
                    ? query.OrderByDescending(g => EF.Property<object>(g, parameters.OrderBy))
                    : query.OrderBy(g => EF.Property<object>(g, parameters.OrderBy));
            }
            // Apply pagination
            if (parameters.Skip.HasValue)
            {
                query = query.Skip(parameters.Skip.Value);
            }
            if (parameters.Take.HasValue)
            {
                query = query.Take(parameters.Take.Value);
            }
            var groupes = await query.AsNoTracking().ToListAsync();




            return groupes;
        }

        public async Task<bool> GroupeExistsInEntityOrParentsAsync(string entiteId, string groupeId)
        {
            return await dbContext.Groupes
        .FromSqlInterpolated($@"
                WITH RECURSIVE entite_hierarchy AS (
                    SELECT ""Id"", ""ParentId""
                    FROM ""Entites""
                    WHERE ""Id"" = {entiteId}

                    UNION ALL

                    SELECT e.""Id"", e.""ParentId""
                    FROM ""Entites"" e
                    INNER JOIN entite_hierarchy eh ON e.""Id"" = eh.""ParentId""
                )
                SELECT r.*
                FROM ""Groupes"" r
                INNER JOIN entite_hierarchy eh ON r.""EntiteId"" = eh.""Id""
                WHERE r.""IsDeleted"" = FALSE
                  AND (r.""EntiteId"" = {entiteId} OR r.""Heritee"" = TRUE)
            ")
        .AnyAsync(x => x.Id == groupeId);

        }

    }
}
