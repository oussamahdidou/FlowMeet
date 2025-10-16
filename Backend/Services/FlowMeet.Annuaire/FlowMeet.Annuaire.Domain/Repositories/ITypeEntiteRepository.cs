using FlowMeet.Annuaire.Domain.Common;
using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Domain.Repositories
{
    public interface ITypeEntiteRepository
    {
        Task<bool> IsLevelExistAsync(int level);
        Task AddAsync(TypeEntite typeEntite);
        Task<TypeEntite?> GetByIdAsync(string id);
        Task DeleteAsync(TypeEntite typeEntite);
        Task<List<TResult>> GetAsync<TResult>(QueryParameters<TypeEntite, TResult> queryParameters)
           where TResult : class;


    }
}
