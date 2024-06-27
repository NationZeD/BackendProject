using System.Data;

namespace BackendProject.Shared.Persistence.SqlConnection;

internal sealed class SqlConnectionFactory(string connectionString) : ISqlConnectionFactory
{
    public IDbConnection CreateConnection()
    {
        var connection = new Microsoft.Data.SqlClient.SqlConnection(connectionString);
        connection.Open();

        return connection;
    }
}