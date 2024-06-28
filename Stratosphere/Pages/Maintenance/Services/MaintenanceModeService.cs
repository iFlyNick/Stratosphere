using Stratosphere.Pages.Maintenance.Data;

namespace Stratosphere.Pages.Maintenance.Services;

public class MaintenanceModeService : IMaintenanceModeService
{
    private readonly IDbRepository _repository;
    private readonly ILogger<MaintenanceModeService> _logger;

    public MaintenanceModeService(ILogger<MaintenanceModeService> logger, IDbRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    
}
