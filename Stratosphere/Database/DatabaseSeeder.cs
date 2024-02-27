namespace Stratosphere.Database;

public class DatabaseSeeder : IDatabaseSeeder
{
    public async Task DropDatabase(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public async Task CreateDatabase(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public async Task PurgeDatabase(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public async Task SeedDatabase(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}
