using Stratosphere.Identity.Services;

namespace Stratosphere.Identity;

public static class Startup
{
    public static void AddMiddlewareServices(this IServiceCollection services)
    {
        //this is injected into middleware so it must be singleton if registered here and not created from iservicescopefactory
        services.AddSingleton<IIdentityService, IdentityService>();
    }
}
