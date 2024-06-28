using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Maintenance.Services;

namespace Stratosphere.Pages.Maintenance;

public class IndexModel : PageModel
{
    private readonly IMaintenanceModeService _service;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, IMaintenanceModeService service)
    {
        _logger = logger;
        _service = service;
    }

    public async Task<IActionResult> OnGet()
    {
        return Page();
    }
}
