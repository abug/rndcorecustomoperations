using System.Data;
using System.Threading.Tasks;
using rndcorecustomoperations.Specifications;
using rndcorecustomoperations.Extensions;
using System;
using System.Collections.Generic;

namespace rndcorecustomoperations.Repositories
{
    public class BaseDapperRepository : IDapperRepository
    {
        private readonly IDbConnection connection;

        public BaseDapperRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<Tuple<IEnumerable<TResponse>>> FindAsync<TRequest, TResponse>(
            IQuery<TRequest> query)
        {
            return await connection.QueryMultipleAsync<TRequest, TResponse>(query);
        }

        public async Task<Tuple<IEnumerable<TResponse1>, IEnumerable<TResponse2>>> FindAsync<TRequest, TResponse1, TResponse2>(IQuery<TRequest> query)
        {
            return await connection.QueryMultipleAsync<TRequest, TResponse1, TResponse2>(query);
        }
    }


}