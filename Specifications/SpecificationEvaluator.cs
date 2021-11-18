using System.Linq;
using Microsoft.EntityFrameworkCore;
using rndcorecustomoperations.Models;

namespace rndcorecustomoperations.Specifications
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(
            IQueryable<TEntity> query, ISpecification<TEntity> specification)
        {
            if (specification == null)
            {
                return query;
            }

            // Modify the IQueryable
            // Apply filter conditions
            if (specification.FilterCondition != null)
            {
                query = query.Where(specification.FilterCondition);
            }

            // Includes
            query = specification.Includes
                        .Aggregate(query, (current, include) => current.Include(include));

            // Apply ordering
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            // Apply GroupBy
            if (specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            return query;
        }

        public static IQuery<TEntity> GetQuery(
            IQuery<TEntity> query, ISpecification<TEntity> specification)
        {
            if (specification == null || !specification.Parameters.Any())
            {
                return query;
            }

            foreach (var parameter in specification.Parameters)
            {
                query.Parameters.Add(parameter);
            }

            return query;
        }
    }
}