using Stratosphere.Pages.Administration.Assets.ViewModels;

namespace Stratosphere.Pages.Administration.Assets.Services;

public class AssetService : IAssetService
{
    public async Task<List<AssetVM>?> GetAssets()
    {
        var retVal = new List<AssetVM>();

        return retVal;
    }
}
