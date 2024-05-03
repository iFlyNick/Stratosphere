using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Queues.Data.Repository;
using Stratosphere.Pages.Queues.ViewModels;
using Stratosphere.Services.Queues;

namespace Stratosphere.Pages.Queues;

public class IndexModel : PageModel
{
    private readonly IQueueApiService _queueApiService;
    private readonly IDbRepository _dbRepository;
    private readonly ILogger<IndexModel> _logger;

    public QueueIndexViewModel? Input { get; set; }

    public IndexModel(IQueueApiService queueApiService, IDbRepository dbRepository, ILogger<IndexModel> logger)
    {
        _queueApiService = queueApiService;
        _dbRepository = dbRepository;
        _logger = logger;

    }

    public async Task<IActionResult> OnGet()
    {
        var resp = await _queueApiService.GetAllQueueInfo(false);
        var envs = await _dbRepository.GetEnvironments();

        Input = new QueueIndexViewModel()
        {
            EnvironmentGroups = envs,
            Queues = resp
        };

        return Page();
    }
}
