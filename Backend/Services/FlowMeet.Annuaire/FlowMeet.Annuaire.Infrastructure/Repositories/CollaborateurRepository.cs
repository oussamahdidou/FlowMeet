using FlowMeet.Annuaire.Domain.Entities;
using FlowMeet.Annuaire.Domain.Repositories;
using FlowMeet.Annuaire.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace FlowMeet.Annuaire.Infrastructure.Repositories
{
    public class CollaborateurRepository : ICollaborateurRepository
    {
        private readonly FlowMeetAnnuaireDbContext dbContext;
        public CollaborateurRepository(FlowMeetAnnuaireDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task AddAsync(Collaborateur collaborateur)
        {
            await dbContext.Collaborateurs.AddAsync(collaborateur);
        }

        public async Task<bool> ExistsInEntiteAsync(string collaborateurId, string entiteId)
        {
            return await dbContext.Collaborateurs.AnyAsync(c => c.Id == collaborateurId && c.EntiteId == entiteId);
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await dbContext.Collaborateurs.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> IsUserNameExistAsync(string userName)
        {
            return await dbContext.Collaborateurs.AnyAsync(c => c.UserName == userName);
        }
    }
}
