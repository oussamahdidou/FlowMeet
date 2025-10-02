﻿namespace FlowMeet.Notification.Domain.Common
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
