using Stratosphere.Pages.Monitoring.Models;

namespace Stratosphere.Pages.Monitoring.Data;

public interface IDbRepository
{
    Task<List<Service>?> GetServices();
}
