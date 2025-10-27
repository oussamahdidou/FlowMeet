using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Domain.Repositories
{
    public interface IRoleCollaborateurRepository
    {
        Task AddAsync(CollaborateurRole collaborateurRole);
        Task DeleteAsync(CollaborateurRole collaborateurRole);
        Task<bool> ExistsAsync(string collaborateurId, string roleId);

        Task<CollaborateurRole> GetByIdsAsync(string collaborateurId, string roleId);
    }
}
