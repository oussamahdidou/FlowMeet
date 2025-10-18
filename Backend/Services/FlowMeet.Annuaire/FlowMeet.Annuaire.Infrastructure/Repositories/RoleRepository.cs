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
    }
}
