using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace Stratosphere.Pages;
public class IndexModel(ILogger<IndexModel> logger, IMemoryCache cache) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IMemoryCache _cache = cache;

    public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
    {
        return Page();
    }

    public IActionResult OnGetSignOut()
    {
        return SignOut(new AuthenticationProperties { RedirectUri = "/" }, CookieAuthenticationDefaults.AuthenticationScheme, OpenIdConnectDefaults.AuthenticationScheme);
    }
}
