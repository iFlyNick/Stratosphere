using Stratosphere.Pages.Monitoring.Models;

namespace Stratosphere.Pages.Monitoring.Services;

public class MonitoringService : IMonitoringService
{
    //protected readonly IDbRepository _repository;
    protected readonly ILogger<MonitoringService> _logger;
    
    public MonitoringService(/*IDbRepository repository, */ILogger<MonitoringService> logger)
    {
        //_repository = repository;
        _logger = logger;
    }

    //public async Task<List<Service>?> GetServices()
    //{
    //    return await _repository.GetServices();
    //}
}
