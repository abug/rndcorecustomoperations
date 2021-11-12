using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Repositories
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQuery<TEntity> GetQuery(
            IQuery<TEntity> query, ISpecification<TEntity> specification)
        {
            if (specification == null)
            {
                return query;
            }

            query.Parameters = specification.Parameters;

            return query;
        }
    }
}