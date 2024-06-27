using System.Data;

namespace BackendProject.Shared.Persistence.SqlConnection;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}