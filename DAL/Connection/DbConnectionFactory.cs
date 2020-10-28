using BSF.DAL.Abstractions.Connection;
using Microsoft.Data.Sqlite;
using System.Data;

namespace BSF.DAL.Connection
{
    internal sealed class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public DbConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}
