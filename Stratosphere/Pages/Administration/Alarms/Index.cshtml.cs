using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Administration.Alarms.Services;
using Stratosphere.Pages.Administration.Alarms.ViewModels;

namespace Stratosphere.Pages.Administration.Alarms;

public class IndexModel(ILogger<IndexModel> logger, IAlarmService service) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IAlarmService _service = service;

    public async Task<IActionResult> OnGetAlarms()
    {
        var alarmsVM = new AlarmsVM()
        {
            Alarms = await _service.GetAlarms()
        };

        return Partial("Partials/_AlarmPartial", alarmsVM);
    }
}
