using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Administration.AssetTypes.Services;
using Stratosphere.Pages.Administration.AssetTypes.ViewModels;

namespace Stratosphere.Pages.Administration.AssetTypes;

public class IndexModel(ILogger<IndexModel> logger, IAssetTypeService assetTypeService) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IAssetTypeService _service = assetTypeService;

    public async Task<IActionResult> OnGetAssetTypes()
    {
        var assetTypesVM = new AssetTypesVM()
        {
            AssetTypes = await _service.GetAssetTypes()
        };

        return Partial("Partials/_AssetTypePartial", assetTypesVM);
    }

    public async Task<IActionResult> OnGetAssetTypesData()
    {
        var assetTypesVM = new AssetTypesVM()
        {
            AssetTypes = await _service.GetAssetTypes()
        };

        return new JsonResult(new { success = true, dataList = assetTypesVM.AssetTypes });
    }

    public async Task<JsonResult> OnPostAssetType([FromBody] AssetTypeVM assetType)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("Invalid model state received for asset type post");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received asset type post request for {assetType}", assetType.Name);

        var dbReturn = await _service.CreateAssetType(assetType);

        if (dbReturn == 0)
        {
            _logger.LogError("Failed to create asset type {assetType}", assetType.Name);
            return new JsonResult(new { success = false });
        }

        return new JsonResult(new { success = true });
    }

    public async Task<JsonResult> OnPutAssetType([FromBody] AssetTypeVM assetType)
    {
        _logger.LogInformation("Received asset type put request. has object: {test}", assetType is null ? "nope" : "yep");

        return new JsonResult(new { success = true });
    }

    public async Task<JsonResult> OnDeleteAssetType(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            _logger.LogInformation("Invalid asset type name received for delete");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received asset type delete request for {assetTypeName}", name);

        await _service.DeleteAssetTypeByName(name);

        return new JsonResult(new { success = true });
    }
}
