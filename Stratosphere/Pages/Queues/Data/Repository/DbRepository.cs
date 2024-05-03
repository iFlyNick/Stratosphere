using Dapper;
using Stratosphere.Data.Postgres.Context;
using Stratosphere.Pages.Queues.Models;

namespace Stratosphere.Pages.Queues.Data.Repository;

public class DbRepository : IDbRepository
{
    protected readonly IPostgresContext _context;
    protected readonly ILogger<DbRepository> _logger;

    public DbRepository(IPostgresContext context, ILogger<DbRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<List<EnvironmentGroup>?> GetEnvironments(CancellationToken cancellationToken = default) 
    {
        var sql = @"select e.environmentid, e.name from stratosphere.environment e";

        var cmd = new CommandDefinition(sql, cancellationToken: cancellationToken);

        var resp = await _context.Connection.QueryAsync<EnvironmentGroup>(cmd);

        return resp.ToList();
    }
}
