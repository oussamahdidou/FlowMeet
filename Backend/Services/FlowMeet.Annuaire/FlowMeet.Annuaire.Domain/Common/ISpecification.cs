namespace FlowMeet.Annuaire.Domain.Common
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
