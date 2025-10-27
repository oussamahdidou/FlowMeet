using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Domain.Repositories
{
    public interface ICollaborateurGroupeRepository
    {
        Task<bool> ExistsAsync(string collaborateurId, string groupeId);
        Task<CollaborateurGroupe?> GetByIdsAsync(string collaborateurId, string groupeId);
        Task AddAsync(CollaborateurGroupe collaborateurGroupe);
        Task DeleteAsync(CollaborateurGroupe collaborateurGroupe);
    }
}
