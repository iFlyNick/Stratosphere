using System.Data;

namespace Stratosphere.Data;

public interface IContext
{
    IDbConnection Connection { get; }
}
