using FlowMeet.Annuaire.Domain.Entities;
using FlowMeet.Annuaire.Domain.Repositories;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.Annuaire.Infrastructure.Repositories
{
    public class CollaborateurGroupeRepository : ICollaborateurGroupeRepository
    {
        private readonly FlowMeetAnnuaireDbContext dbContext;
        public CollaborateurGroupeRepository(FlowMeetAnnuaireDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddAsync(CollaborateurGroupe collaborateurGroupe)
        {
            await dbContext.CollaborateurGroupes.AddAsync(collaborateurGroupe);
        }

        public Task DeleteAsync(CollaborateurGroupe collaborateurGroupe)
        {
            dbContext.CollaborateurGroupes.Remove(collaborateurGroupe);
            return Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(string collaborateurId, string groupeId)
        {
            return await dbContext.CollaborateurGroupes
                .AnyAsync(cg => cg.CollaborateurId == collaborateurId && cg.GroupeId == groupeId);
        }

        public Task<CollaborateurGroupe?> GetByIdsAsync(string collaborateurId, string groupeId)
        {
            return dbContext.CollaborateurGroupes
                .FirstOrDefaultAsync(cg => cg.CollaborateurId == collaborateurId && cg.GroupeId == groupeId);
        }

        // Implement repository methods here
    }
}
