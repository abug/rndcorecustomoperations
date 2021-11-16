using System;
using System.Collections.Generic;
using Dapper;

namespace rndcorecustomoperations.Specifications
{
    public interface ISpecification<TEntity>
    {
        public IDictionary<string, string> Parameters { get; }       
    }
}