using System.Data;

namespace SpaceConnectMonitor.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
