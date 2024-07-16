using Stratosphere.Pages.Monitoring.Services;

namespace Stratosphere.Pages.Monitoring;

public static class Startup
{
    public static void AddMonitoringServices(this IServiceCollection services)
    {
        services.AddScoped<IMonitoringService, MonitoringService>();
    }
}
