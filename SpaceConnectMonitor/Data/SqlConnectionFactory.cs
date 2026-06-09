using System.Data;
using Microsoft.Data.SqlClient;

namespace SpaceConnectMonitor.Data;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        var connectionString = _configuration.GetConnectionString("SpaceConnectDb")
            ?? throw new InvalidOperationException("Connection string SpaceConnectDb não configurada.");
        return new SqlConnection(connectionString);
    }
}
