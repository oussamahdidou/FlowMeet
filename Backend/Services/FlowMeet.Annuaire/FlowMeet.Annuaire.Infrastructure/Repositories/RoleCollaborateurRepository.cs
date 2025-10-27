using FlowMeet.Annuaire.Domain.Entities;
using FlowMeet.Annuaire.Domain.Repositories;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.Annuaire.Infrastructure.Repositories
{
    public class RoleCollaborateurRepository : IRoleCollaborateurRepository
    {
        private readonly FlowMeetAnnuaireDbContext dbContext;
        public RoleCollaborateurRepository(FlowMeetAnnuaireDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(CollaborateurRole collaborateurRole)
        {
            await dbContext.CollaborateurRoles.AddAsync(collaborateurRole);
        }

        public Task DeleteAsync(CollaborateurRole collaborateurRole)
        {
            dbContext.CollaborateurRoles.Remove(collaborateurRole);
            return Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(string collaborateurId, string roleId)
        {
            return await dbContext.CollaborateurRoles.AnyAsync(cr => cr.CollaborateurId == collaborateurId && cr.RoleId == roleId);
        }
    }
}
