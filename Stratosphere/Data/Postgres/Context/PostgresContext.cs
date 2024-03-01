using Npgsql;
using System.Data;

namespace Stratosphere.Data.Postgres.Context;

public class PostgresContext : IPostgresContext
{
    private readonly string? _connectionString;
    private IDbConnection? _connection;

    public IDbConnection Connection
    {
        get
        {
            if (string.IsNullOrEmpty(_connection?.ConnectionString) || _connection.State == ConnectionState.Broken)
                _connection = new NpgsqlConnection(_connectionString);

            return _connection;
        }
    }

    public PostgresContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Postgres");
    }
}
