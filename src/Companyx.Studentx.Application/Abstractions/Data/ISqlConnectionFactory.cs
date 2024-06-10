using System.Data;

namespace Companyx.Companyx.Studentx.Application.Abstractions.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
