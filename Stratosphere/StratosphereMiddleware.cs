using Stratosphere.Identity.Services;

namespace Stratosphere;

public class StratosphereMiddleware(ILogger<StratosphereMiddleware> logger, RequestDelegate next, IIdentityService identityService)
{
    private readonly ILogger<StratosphereMiddleware> _logger = logger;
    private readonly RequestDelegate _next = next;
    private readonly IIdentityService _identityService = identityService;

    public async Task Invoke(HttpContext context)
    {
        if (context.User is not null && (context.User.Identity?.IsAuthenticated ?? false))
            await _identityService.AddUserClaims(context.User, context.RequestAborted);

        await _next(context);
    }
}
