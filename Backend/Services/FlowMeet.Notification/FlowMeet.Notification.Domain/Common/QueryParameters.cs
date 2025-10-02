using System.Linq.Expressions;

namespace FlowMeet.Notification.Domain.Common
{
    public class QueryParameters<TEntity, TResult>
    {
        public Expression<Func<TEntity, bool>>? Filter { get; set; }             // Where
        public List<Expression<Func<TEntity, object>>>? OrderBy { get; set; }    // OrderBy
        public bool OrderByDescending { get; set; } = false;
        public int? Skip { get; set; }                                           // Pagination
        public int? Take { get; set; }                                           // Pagination
        public Expression<Func<TEntity, TResult>>? Selector { get; set; }        // Projection
        public List<Expression<Func<TEntity, object>>>? Includes { get; set; }  // Include / ThenInclude
    }

    //public async Task<List<TResult>> GetAsync<TEntity, TResult>(QueryParameters<TEntity, TResult> queryParameters)
    //    where TEntity : class
    //        {
    //            IQueryable<TEntity> queryable = _context.Set<TEntity>();

    //            // Includes
    //            if (queryParameters.Includes != null)
    //            {
    //                foreach (var include in queryParameters.Includes)
    //                {
    //                    queryable = queryable.Include(include);
    //                }
    //            }

    //            // Filter
    //            if (queryParameters.Filter != null)
    //                queryable = queryable.Where(queryParameters.Filter);

    //            // Sorting (OrderBy / ThenBy)
    //            if (queryParameters.OrderBy != null && queryParameters.OrderBy.Any())
    //            {
    //                IOrderedQueryable<TEntity>? orderedQuery = null;
    //                for (int i = 0; i < queryParameters.OrderBy.Count; i++)
    //                {
    //                    var orderExpr = queryParameters.OrderBy[i];
    //                    if (i == 0)
    //                    {
    //                        orderedQuery = queryParameters.OrderByDescending
    //                            ? queryable.OrderByDescending(orderExpr)
    //                            : queryable.OrderBy(orderExpr);
    //                    }
    //                    else
    //                    {
    //                        orderedQuery = queryParameters.OrderByDescending
    //                            ? orderedQuery.ThenByDescending(orderExpr)
    //                            : orderedQuery.ThenBy(orderExpr);
    //                    }
    //                }
    //                queryable = orderedQuery!;
    //            }

    //            // Pagination
    //            if (queryParameters.Skip.HasValue)
    //                queryable = queryable.Skip(queryParameters.Skip.Value);
    //            if (queryParameters.Take.HasValue)
    //                queryable = queryable.Take(queryParameters.Take.Value);

    //            // Projection
    //            if (queryParameters.Selector != null)
    //            {
    //                return await queryable.Select(queryParameters.Selector).ToListAsync();
    //            }
    //            else
    //            {
    //                Expression<Func<TEntity, TResult>> identity = e => (TResult)(object)e;
    //                return await queryable.Select(identity).ToListAsync();
    //            }
    //        }


}
