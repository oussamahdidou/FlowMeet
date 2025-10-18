using FlowMeet.Annuaire.Domain.Common;
using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Domain.Repositories
{
    public interface IEntiteRepository
    {
        Task AddAsync(Entite entite);
        Task<Entite?> GetByIdAsync(string id);
        Task<Entite?> GetEntiteHiearchyAsync(string id);
        Task DeleteAsync(Entite entite);
        Task<List<Entite>> GetAllAsync(QueryParameters queryParams);
        Task<Entite?> GetRootEntiteHiearchyAsync();
    }
}
