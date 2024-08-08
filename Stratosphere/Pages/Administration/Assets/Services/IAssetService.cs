using Stratosphere.Pages.Administration.Assets.ViewModels;

namespace Stratosphere.Pages.Administration.Assets.Services;

public interface IAssetService
{
    Task<List<AssetVM>?> GetAssets();
}
