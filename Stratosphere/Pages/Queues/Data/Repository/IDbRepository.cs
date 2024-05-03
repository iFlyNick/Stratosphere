using Stratosphere.Pages.Queues.Models;

namespace Stratosphere.Pages.Queues.Data.Repository;

public interface IDbRepository
{
    Task<List<EnvironmentGroup>?> GetEnvironments(CancellationToken cancellationToken = default);
}
