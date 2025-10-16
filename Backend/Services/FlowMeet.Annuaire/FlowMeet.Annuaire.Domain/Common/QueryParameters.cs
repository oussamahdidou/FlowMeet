using System.Linq.Expressions;

namespace FlowMeet.Annuaire.Domain.Common
{
    public class QueryParameters<TEntity, TResult>
    {
        public string? Filter { get; set; }
        public string? OrderBy { get; set; }
        public bool OrderByDescending { get; set; } = false;
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public Expression<Func<TEntity, TResult>> Selector { get; set; }
    }



}
