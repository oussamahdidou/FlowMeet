using FlowMeet.Annuaire.Domain.Common;
using FlowMeet.Annuaire.Domain.Entities;
using FlowMeet.Annuaire.Domain.Repositories;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.Annuaire.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly FlowMeetAnnuaireDbContext dbContext;
        public RoleRepository(FlowMeetAnnuaireDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(Role role)
        {
            await dbContext.Roles.AddAsync(role);
        }

        public Task DeleteAsync(Role role)
        {
            dbContext.Roles.Remove(role);
            return Task.CompletedTask;
        }

        public Task<List<Role>> GetAllAsync(QueryParameters queryParams)
        {
            IQueryable<Role> query = dbContext.Roles;
            // Apply filtering
            if (!string.IsNullOrEmpty(queryParams.Filter))
            {
                query = query.Where(r => r.Label.Contains(queryParams.Filter));
            }
            // Apply sorting
            if (!string.IsNullOrEmpty(queryParams.OrderBy))
            {
                query = queryParams.OrderByDescending
                    ? query.OrderByDescending(r => EF.Property<object>(r, queryParams.OrderBy))
                    : query.OrderBy(r => EF.Property<object>(r, queryParams.OrderBy));
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

        public Task<Role?> GetByIdAsync(string id)
        {
            return dbContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }
        /// <summary>
        /// ✅ Get all roles of the entity and heritable roles from its parent entities.
        /// </summary>
        public async Task<List<Role>> GetEntityAndInheritedRolesAsync(string entiteId)
        {
            var roles = await dbContext.Roles
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
                FROM ""Roles"" r
                INNER JOIN entite_hierarchy eh ON r.""EntiteId"" = eh.""Id""
                WHERE r.""IsDeleted"" = FALSE
                  AND (r.""EntiteId"" = {entiteId} OR r.""Heritee"" = TRUE);
            ")
                .AsNoTracking()
                .ToListAsync();

            return roles;
        }

        /// <summary>
        /// ✅ Check if a role exists in the entity or in heritable parent roles.
        /// </summary>
        public async Task<bool> RoleExistsInEntityOrParentsAsync(string entiteId, string roleId)
        {
            return await dbContext.Roles
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
                FROM ""Roles"" r
                INNER JOIN entite_hierarchy eh ON r.""EntiteId"" = eh.""Id""
                WHERE r.""IsDeleted"" = FALSE
                  AND (r.""EntiteId"" = {entiteId} OR r.""Heritee"" = TRUE);
            ")
      .AnyAsync(x => x.Id == roleId);

        }

    }
}
