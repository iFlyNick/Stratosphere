using Stratosphere.Data;
using System.Security.Claims;

namespace Stratosphere.Identity.Services;

public class IdentityService(ILogger<IdentityService> logger, IServiceScopeFactory serviceScopeFactory) : IIdentityService
{
    private readonly ILogger<IdentityService> _logger = logger;
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

    //this ends up being singleton so be aware of that when managing the class and state

    public async Task AddUserClaims(ClaimsPrincipal? principal, CancellationToken ct = default)
    {
        if (principal is null || principal.Claims is null)
            return;

        //spin up new instance of dbcontext to append user claims from db
        using var scope = _serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<StratosphereContext>();

        return;
    }
}
