using Stratosphere.Pages.Queues.Data.Repository;

namespace Stratosphere.Pages.Queues;

public static class Startup
{
    public static void AddQueueServices(this IServiceCollection services)
    {
        services.AddScoped<IDbRepository, DbRepository>();
    }
}
