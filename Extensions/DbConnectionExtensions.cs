using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using rndcorecustomoperations.Specifications;

namespace rndcorecustomoperations.Extensions
{
    public static class DbConnectionExtensions
    {
        public static Task<IEnumerable<T>> QueryListAsync<T>(
            this IDbConnection cnn, IQuery<T> query)
        {
            var parameters = new DynamicParameters();
            foreach (var parameter in query.Parameters)
            {
                parameters.Add(parameter.Key, parameter.Value);
            }

            var command = new CommandDefinition(query.QueryBody, parameters,
                commandType: CommandType.StoredProcedure);

            return cnn.QueryAsync<T>(command);
        }
    }
}