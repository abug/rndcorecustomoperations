using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dapper;

namespace rndcorecustomoperations.Specifications
{
    public interface ISpecification<TEntity>
    {
        public IDictionary<string, string> Parameters { get; }

        Expression<Func<TEntity, bool>> FilterCondition { get; }

        Expression<Func<TEntity, object>> OrderBy { get; }

        Expression<Func<TEntity, object>> OrderByDescending { get; }

        List<Expression<Func<TEntity, object>>> Includes { get; }

        Expression<Func<TEntity, object>> GroupBy { get; }
    }
}