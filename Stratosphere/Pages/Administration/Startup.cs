using Stratosphere.Pages.Administration.Alarms.Services;
using Stratosphere.Pages.Administration.Assets.Services;
using Stratosphere.Pages.Administration.Contacts.Services;
using Stratosphere.Pages.Administration.Data;
using Stratosphere.Pages.Administration.Environments.Services;
using Stratosphere.Pages.Administration.Queues.Services;
using Stratosphere.Pages.Administration.Services.Services;
using Stratosphere.Pages.Administration.ServiceTypes.Services;
using Stratosphere.Pages.Administration.Users.Services;

namespace Stratosphere.Pages.Administration;

public static class Startup
{
    public static void AddAdministrationServices(this IServiceCollection services)
    {
        services.AddScoped<IDbRepository, DbRepository>();

        services.AddScoped<IAlarmService, AlarmService>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IEnvironmentService, EnvironmentService>();
        services.AddScoped<IQueueAdminService, QueueAdminService>();
        services.AddScoped<IServicesService, ServicesService>();
        services.AddScoped<IServiceTypeService, ServiceTypeService>();
        services.AddScoped<IUserService, UserService>();
    }
}
