using System;
using System.Collections.Generic;
using Dapper;

namespace rndcorecustomoperations.Repositories
{
    public interface ISpecification<TEntity>
    {
        public IDictionary<string, string> Parameters { get; }       
    }
}