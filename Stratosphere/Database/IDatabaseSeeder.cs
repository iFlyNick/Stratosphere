namespace Stratosphere.Database;

public interface IDatabaseSeeder
{
    Task DropDatabase(CancellationToken cancellationToken); //fully reset the database
    Task CreateDatabase(CancellationToken cancellationToken); //create skeleton of the database
    Task PurgeDatabase(CancellationToken cancellationToken); //remove all data from the database
    Task SeedDatabase(CancellationToken cancellationToken); //populate with starter data
}
