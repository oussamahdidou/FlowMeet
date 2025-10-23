using FlowMeet.Annuaire.Domain.Common;
using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Domain.Repositories
{
    public interface IGroupeRepository
    {
        Task AddAsync(Groupe groupe);
        Task<List<Groupe>> GroupeExistsInEntityOrParentsAsync(string entiteId, QueryParameters parameters);
        Task<Groupe?> GetByIdAsync(string id);
        Task<List<Groupe>> GetAllAsync(QueryParameters queryParameters);
        Task<bool> GroupeExistsInEntiteAsync(string groupeId, string entiteId);
    }
}
