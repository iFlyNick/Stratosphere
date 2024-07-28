using Stratosphere.Pages.Maintenance.Services;

namespace Stratosphere.Pages.Maintenance;

public static class Startup
{
    public static void AddMaintenanceServices(this IServiceCollection services)
    {
        services.AddScoped<IMaintenanceModeService, MaintenanceModeService>();
    }
}
