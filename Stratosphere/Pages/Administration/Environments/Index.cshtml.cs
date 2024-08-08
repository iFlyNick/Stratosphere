using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Administration.Environments.Services;
using Stratosphere.Pages.Administration.Environments.ViewModels;

namespace Stratosphere.Pages.Administration.Environments;

public class IndexModel(ILogger<IndexModel> logger, IEnvironmentService service) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IEnvironmentService _service = service;

    public async Task<IActionResult> OnGetEnvironments()
    {
        var environmentsVM = new EnvironmentsVM()
        {
            Environments = await _service.GetEnvironments()
        };

        return Partial("Partials/_EnvironmentPartial", environmentsVM);
    }
}
