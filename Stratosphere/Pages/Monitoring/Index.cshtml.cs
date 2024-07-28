using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Monitoring.Services;
using Stratosphere.Pages.Monitoring.ViewModels;

namespace Stratosphere.Pages.Monitoring;

public class IndexModel : PageModel
{
    private readonly IMonitoringService _monitoringService;

    public MonitoringIndexViewModel? Input { get; set; }

    public IndexModel(IMonitoringService monitoringService)
    {
        _monitoringService = monitoringService;
    }

    public async Task<IActionResult> OnGet()
    {
        //var services = await _monitoringService.GetServices();

        Input = new MonitoringIndexViewModel
        {
            Services = null
        };

        return Page();
    }
}
