using FlowMeet.Annuaire.Domain.Entities;

namespace FlowMeet.Annuaire.Domain.Repositories
{
    public interface IRoleGroupeRepository
    {
        Task AddAsync(RoleGroupe roleGroupe);
        Task DeleteAsync(RoleGroupe roleGroupe);
    }
}
