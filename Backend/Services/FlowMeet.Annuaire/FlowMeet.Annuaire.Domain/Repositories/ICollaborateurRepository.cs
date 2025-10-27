using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Domain.Repositories
{
    public interface ICollaborateurRepository
    {
        Task<bool> IsUserNameExistAsync(string userName);
        Task<bool> IsEmailExistAsync(string email);
        Task AddAsync(Collaborateur collaborateur);
        Task<bool> ExistsInEntiteAsync(string collaborateurId, string entiteId);


    }
}
