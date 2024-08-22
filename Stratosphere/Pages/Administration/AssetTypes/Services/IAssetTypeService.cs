using Stratosphere.Pages.Administration.AssetTypes.ViewModels;

namespace Stratosphere.Pages.Administration.AssetTypes.Services;

public interface IAssetTypeService
{
    Task<List<AssetTypeVM>?> GetAssetTypes();
    Task<AssetTypeVM?> GetAssetTypeByName(string? name);
    Task<int> CreateAssetType(AssetTypeVM? assetType);
    Task<int> DeleteAssetTypeByName(string? name);
}
