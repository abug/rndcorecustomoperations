using System;
using System.Data;
using System.Data.Common;
using Microsoft.Data.SqlClient;

namespace rndcorecustomoperations.Repositories
{
    public class DatabaseConnection : DbConnection, IDatabaseConnection, ISynapseConnection
    {
        private readonly SqlConnection _connection;

        public DatabaseConnection()
        {
            _connection = new SqlConnection();
        }

        public DatabaseConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public override string ConnectionString { get => _connection.ConnectionString; set => _connection.ConnectionString = value; }

        public override string Database => _connection.Database;

        public override string DataSource => _connection.DataSource;

        public override string ServerVersion => _connection.ServerVersion;

        public override ConnectionState State => _connection.State;

        public override void ChangeDatabase(string databaseName)
        {
            _connection.ChangeDatabase(databaseName);
        }

        public override void Close()
        {
            _connection.Close();
        }

        public override void Open()
        {
            _connection.Open();
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            return _connection.BeginTransaction(isolationLevel);
        }

        protected override DbCommand CreateDbCommand()
        {
            return _connection.CreateCommand();
        }
    }
}