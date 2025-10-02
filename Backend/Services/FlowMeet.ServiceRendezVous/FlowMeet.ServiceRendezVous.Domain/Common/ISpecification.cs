namespace FlowMeet.ServiceRendezVous.Domain.Common
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
