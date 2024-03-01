namespace Stratosphere.Services.Database;

public interface IDatabaseService
{
    Task CreateSchema(CancellationToken cancellationToken = default);
    Task CreateDatabase(CancellationToken cancellationToken = default);
}
