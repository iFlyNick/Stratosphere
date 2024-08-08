using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Administration.Queues.Services;
using Stratosphere.Pages.Administration.Queues.ViewModels;

namespace Stratosphere.Pages.Administration.Queues;

public class IndexModel(ILogger<IndexModel> logger, IQueueAdminService service) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IQueueAdminService _service = service;

    public async Task<IActionResult> OnGetQueues()
    {
        var queuesVM = new QueuesVM()
        {
            Queues = await _service.GetQueues()
        };

        return Partial("Partials/_QueuePartial", queuesVM);
    }
}
