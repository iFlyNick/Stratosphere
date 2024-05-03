using Stratosphere.Pages.Monitoring.Models;

namespace Stratosphere.Pages.Monitoring.Services;

public interface IMonitoringService
{
    Task<List<Service>?> GetServices();
}
