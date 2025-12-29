using System.Data;

namespace Tasker.Application.Abstraction.Data;

public interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}