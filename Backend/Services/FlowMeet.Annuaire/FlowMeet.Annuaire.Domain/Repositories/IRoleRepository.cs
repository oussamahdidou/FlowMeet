using FlowMeet.Annuaire.Domain.Common;
using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task AddAsync(Role role);
        Task DeleteAsync(Role role);
        Task<List<Role>> GetAllAsync(QueryParameters queryParams);
        Task<Role?> GetByIdAsync(string id);
        Task<bool> RoleExistsInEntityOrParentsAsync(string entiteId, string roleId);
        Task<List<Role>> GetEntityAndInheritedRolesAsync(string entiteId, QueryParameters parameters);
    }
}
