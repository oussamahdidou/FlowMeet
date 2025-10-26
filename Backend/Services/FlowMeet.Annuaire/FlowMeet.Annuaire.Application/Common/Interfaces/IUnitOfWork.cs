using FlowMeet.Annuaire.Domain.Repositories;

namespace FlowMeet.Annuaire.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ITypeEntiteRepository TypeEntites { get; }
        IEntiteRepository Entites { get; }
        IRoleRepository Roles { get; }
        IGroupeRepository Groupes { get; }
        IRoleGroupeRepository GroupeRoles { get; }
        ICollaborateurRepository Collaborateurs { get; }
        Task SaveChanges();
    }
}
