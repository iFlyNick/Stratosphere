using Dapper;
using Stratosphere.Data.Postgres.Context;
using System.Data;

namespace Stratosphere.Data.Postgres.Repository;

public class PostgresRepository : IPostgresRepository
{
    protected readonly IPostgresContext _context;
    protected readonly IConfiguration _configuration;
    protected readonly ILogger<PostgresRepository> _logger;

    //postgres isn't a big fan of uppercase schema names in queries, luckily i'm not either so this works out.
    private readonly string _schemaName = "stratosphere";

    public PostgresRepository(IPostgresContext context, IConfiguration configuration, ILogger<PostgresRepository> logger)
    {
        _context = context;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task<int?> CreateSchema(CancellationToken cancellationToken = default)
    {
        var check = "select 1 from information_schema.schemata where schema_name = @schemaName";
        var checkParams = new { schemaName = _schemaName };
        var checkRes = await _context.Connection.QueryFirstOrDefaultAsync<int>(check, checkParams);

        if (checkRes == 1)
        {
            _logger.LogInformation($"Schema {_schemaName} already exists, skipping creation.");
            return null;
        }

        //can't paramaterize schema names as it'll pass with quotes around it and postgres can't handle that
        var sql = $"create schema if not exists {_schemaName}";

        _logger.LogInformation($"Creating schema: {_schemaName}");

        var result = _context.Connection.Execute(sql);

        return result;
    }

    public async Task<int?> CreateTable(string? tableName, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(tableName)) return null;

        var check = "select 1 from information_schema.tables where table_schema = @schemaName and table_name = @tableName";
        var checkParams = new { schemaName = _schemaName, tableName = tableName.ToLowerInvariant() };
        var checkRes = await _context.Connection.QueryFirstOrDefaultAsync<int>(check, checkParams);

        if (checkRes == 1)
        {
            _logger.LogInformation($"{tableName} already exists in schema {_schemaName}, skipping creation.");
            return null;
        }

        //pull sql file from ~/Database/Postgres/Scripts/Tables/{tableName}.sql and run the sql in the file
        var fileSql = await File.ReadAllTextAsync(Path.Combine(Directory.GetCurrentDirectory(), "Database", "Postgres", "Scripts", "Tables", $"{tableName}.sql"), cancellationToken);

        var sql = new CommandDefinition(fileSql, cancellationToken: cancellationToken);

        _logger.LogInformation($"Creating table: {tableName}");

        var res = await _context.Connection.ExecuteAsync(sql);

        return res;
    }
}
