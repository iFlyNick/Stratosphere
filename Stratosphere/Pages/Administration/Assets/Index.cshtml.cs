using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Administration.Assets.Services;
using Stratosphere.Pages.Administration.Assets.ViewModels;

namespace Stratosphere.Pages.Administration.Assets;

public class IndexModel(ILogger<IndexModel> logger, IAssetService service) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IAssetService _service = service;

    public async Task<IActionResult> OnGetAssets()
    {
        var assetsVM = new AssetsVM()
        {
            Assets = await _service.GetAssets()
        };

        return Partial("Partials/_AssetPartial", assetsVM);
    }
}
