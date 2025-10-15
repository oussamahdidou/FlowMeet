using FlowMeet.Annuaire.Domain.Repositories;

namespace FlowMeet.Annuaire.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ITypeEntiteRepository TypeEntites { get; }
        Task SaveChanges();
    }
}
