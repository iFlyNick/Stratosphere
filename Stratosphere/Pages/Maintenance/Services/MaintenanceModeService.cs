namespace Stratosphere.Pages.Maintenance.Services;

public class MaintenanceModeService : IMaintenanceModeService
{
    private readonly ILogger<MaintenanceModeService> _logger;

    public MaintenanceModeService(ILogger<MaintenanceModeService> logger)
    {
        _logger = logger;
    } 
}
