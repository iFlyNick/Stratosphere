using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stratosphere.Pages.Administration;

public class IndexModel(ILogger<IndexModel> logger) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;

    public async Task<IActionResult> OnGet()
    {
        return Page();
    }
}
