using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using rndcorecustomoperations.Specifications;

namespace rndcorecustomoperations.Repositories
{
    public interface IDapperRepository
    {
        Task<Tuple<IEnumerable<TResponse>>> FindAsync<TRequest, TResponse>(IQuery<TRequest> query);
        
        Task<Tuple<IEnumerable<TResponse1>, IEnumerable<TResponse2>>> FindAsync<TRequest, TResponse1, TResponse2>(IQuery<TRequest> query);
    }
}