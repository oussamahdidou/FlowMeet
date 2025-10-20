using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Domain.Repositories
{
    public interface IRoleGroupeRepository
    {
        Task AddAsync(RoleGroupe roleGroupe);
        Task<RoleGroupe?> GetRoleGroupeAsync(string groupeId, string roleId);
        Task DeleteAsync(RoleGroupe roleGroupe);
    }
}
