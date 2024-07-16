using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Queues.ViewModels;
using Stratosphere.Services.Queues;

namespace Stratosphere.Pages.Queues;

public class IndexModel : PageModel
{
    private readonly IQueueApiService _queueApiService;
    private readonly ILogger<IndexModel> _logger;

    public QueueIndexViewModel? Input { get; set; }

    public IndexModel(IQueueApiService queueApiService, ILogger<IndexModel> logger)
    {
        _queueApiService = queueApiService;
        _logger = logger;

    }

    public async Task<IActionResult> OnGet()
    {
        var resp = await _queueApiService.GetAllQueueInfo(false);

        Input = new QueueIndexViewModel()
        {
            EnvironmentGroups = null,
            Queues = resp
        };

        return Page();
    }
}
