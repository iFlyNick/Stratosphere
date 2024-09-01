using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Administration.ConnectionProfiles.Services;
using Stratosphere.Pages.Administration.ConnectionProfiles.ViewModels;

namespace Stratosphere.Pages.Administration.ConnectionProfiles;

public class IndexModel(ILogger<IndexModel> logger, IConnectionProfileService connectionProfileService) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IConnectionProfileService _service = connectionProfileService;

    public async Task<IActionResult> OnGetConnectionProfiles()
    {
        var connectionProfilesVM = new ConnectionProfilesVM()
        {
            ConnectionProfiles = await _service.GetConnectionProfiles()
        };

        return Partial("Partials/_ConnectionProfilePartial", connectionProfilesVM);
    }

    public async Task<IActionResult> OnGetConnectionProfilesData()
    {
        var connectionProfilesVM = new ConnectionProfilesVM()
        {
            ConnectionProfiles = await _service.GetConnectionProfiles()
        };

        return new JsonResult(new { success = true, dataList = connectionProfilesVM.ConnectionProfiles });
    }

    public async Task<JsonResult> OnPostConnectionProfile([FromBody] ConnectionProfileVM connectionProfile)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("Invalid model state received for connection profile post");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received connection profile post request for {connectionProfile}", connectionProfile.Name);

        var dbReturn = await _service.CreateConnectionProfile(connectionProfile);

        if (dbReturn == 0)
        {
            _logger.LogError("Failed to create connection profile {connectionProfile}", connectionProfile.Name);
            return new JsonResult(new { success = false });
        }

        return new JsonResult(new { success = true });
    }

    public async Task<JsonResult> OnPutConnectionProfile([FromBody] ConnectionProfileVM connectionProfile)
    {
        _logger.LogInformation("Received asset type put request. has object: {test}", connectionProfile is null ? "nope" : "yep");

        return new JsonResult(new { success = true });
    }

    public async Task<JsonResult> OnDeleteConnectionProfile(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            _logger.LogInformation("Invalid connection profile name received for delete");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received connection profile delete request for {connectionProfileName}", name);

        await _service.DeleteConnectionProfileByName(name);

        return new JsonResult(new { success = true });
    }
}
