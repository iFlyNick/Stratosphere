using Stratosphere.Pages.Maintenance.Data;
using Stratosphere.Pages.Maintenance.Services;

namespace Stratosphere.Pages.Maintenance;

public static class Startup
{
    public static void AddMonitoringServices(this IServiceCollection services)
    {
        services.AddScoped<IDbRepository, DbRepository>();
        services.AddScoped<IMaintenanceModeService, MaintenanceModeService>();
    }
}
