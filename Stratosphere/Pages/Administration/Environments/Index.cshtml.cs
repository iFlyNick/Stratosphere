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

    public async Task<IActionResult> OnGetEnvironmentsData()
    {
        var environmentsVM = new EnvironmentsVM()
        {
            Environments = await _service.GetEnvironments()
        };

        return new JsonResult(new { success = true, dataList = environmentsVM.Environments });
    }

    public async Task<JsonResult> OnPostEnvironment([FromBody] EnvironmentVM environment)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("Invalid model state received for environment post");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received environment post request for {environment}", environment.Name);

        var dbReturn = await _service.CreateEnvironment(environment);

        if (dbReturn == 0)
        {
            _logger.LogError("Failed to create environment {environment}", environment.Name);
            return new JsonResult(new { success = false });
        }

        return new JsonResult(new { success = true });
    }

    public async Task<JsonResult> OnPutEnvironment([FromBody] EnvironmentVM environment)
    {
        _logger.LogInformation("Received environment put request. has object: {test}", environment is null ? "nope" : "yep");

        return new JsonResult(new { success = true });
    }

    public async Task<JsonResult> OnDeleteEnvironment(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            _logger.LogInformation("Invalid environment name received for delete");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received environment delete request for {environment}", name);

        await _service.DeleteEnvironmentByName(name);

        return new JsonResult(new { success = true });
    }
}
