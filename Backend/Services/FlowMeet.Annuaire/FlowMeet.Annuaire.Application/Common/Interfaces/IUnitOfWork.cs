using FlowMeet.Annuaire.Domain.Repositories;

namespace FlowMeet.Annuaire.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ITypeEntiteRepository TypeEntites { get; }
        IEntiteRepository Entites { get; }
        IRoleRepository Roles { get; }
        IGroupeRepository Groupes { get; }
        Task SaveChanges();
    }
}
