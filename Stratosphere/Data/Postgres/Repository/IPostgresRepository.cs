namespace Stratosphere.Data.Postgres.Repository;

public interface IPostgresRepository
{
    Task<int?> CreateSchema(CancellationToken cancellationToken = default);
    Task<int?> CreateTable(string? tableName, CancellationToken cancellationToken = default);
}
