using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Services.Database;

namespace Stratosphere.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    protected readonly IDatabaseService _dbService;

    public IndexModel(ILogger<IndexModel> logger, IDatabaseService dbService)
    {
        _logger = logger;
        _dbService = dbService;
    }

    public async Task<IActionResult> OnGet(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            //await _dbService.CreateSchema(cancellationToken);
            //await _dbService.CreateDatabase(cancellationToken);
        } 
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating database");
        }

        return Page();
    }
}
