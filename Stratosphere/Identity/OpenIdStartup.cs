using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

namespace Stratosphere.Identity;

public static class OpenIdStartup
{
    public static void AddOpenIdConnect(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.Unspecified;
            options.HandleSameSiteCookieCompatibility();
        });

        services.AddMicrosoftIdentityWebAppAuthentication(configuration, "AzureAdB2C");
        services.AddControllersWithViews().AddMicrosoftIdentityUI();

        services.AddRazorPages();
    }
}
