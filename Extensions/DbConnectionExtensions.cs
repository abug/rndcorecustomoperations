using System;
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
        public static async Task<Tuple<IEnumerable<TResponse1>>> QueryMultipleAsync<TRequest, TResponse1>(
            this IDbConnection connection, IQuery<TRequest> query)
        {
            var command = BuildCommandDefinition<TRequest>(query);

            using var reader = await connection.QueryMultipleAsync(command);

            var response1 = await reader.ReadAsync<TResponse1>();

            return new Tuple<IEnumerable<TResponse1>>(response1);
        }

        public static async Task<Tuple<IEnumerable<TResponse1>, IEnumerable<TResponse2>>> QueryMultipleAsync<TRequest, TResponse1, TResponse2>(
            this IDbConnection connection, IQuery<TRequest> query)
        {
            var command = BuildCommandDefinition<TRequest>(query);

            using var reader = await connection.QueryMultipleAsync(command);

            var response1 = await reader.ReadAsync<TResponse1>();
            var response2 = await reader.ReadAsync<TResponse2>();

            return new Tuple<IEnumerable<TResponse1>, IEnumerable<TResponse2>>(response1, response2);
        }

        public static async Task<Tuple<IEnumerable<TResponse1>, IEnumerable<TResponse2>, IEnumerable<TResponse3>>> QueryMultipleAsync<TRequest, TResponse1, TResponse2, TResponse3>(
            this IDbConnection connection, IQuery<TRequest> query)
        {
            var command = BuildCommandDefinition<TRequest>(query);

            using var reader = await connection.QueryMultipleAsync(command);

            var response1 = await reader.ReadAsync<TResponse1>();
            var response2 = await reader.ReadAsync<TResponse2>();
            var response3 = await reader.ReadAsync<TResponse3>();

            return new Tuple<IEnumerable<TResponse1>, IEnumerable<TResponse2>, IEnumerable<TResponse3>>(response1, response2, response3);
        }

        public static async Task<IEnumerable<T>> QueryListAsync<T>(
            this IDbConnection cnn, IQuery<T> query)
        {
            var command = BuildCommandDefinition<T>(query);

            return await cnn.QueryAsync<T>(command);
        }

        private static CommandDefinition BuildCommandDefinition<T>(IQuery<T> query)
        {
            var parameters = new DynamicParameters();

            foreach (var parameter in query.Parameters)
            {
                if (parameter.Value is DataTable)
                {
                    var tableParameter = parameter.Value as DataTable;

                    parameters.Add(parameter.Key, tableParameter.AsTableValuedParameter());    
                }
            }

            var command = new CommandDefinition(query.QueryBody, parameters,
                commandType: CommandType.StoredProcedure);

            return command;
        }
    }
}