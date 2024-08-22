using Stratosphere.Data.Models;
using Stratosphere.Pages.Administration.AssetTypes.ViewModels;
using Stratosphere.Pages.Administration.Data;

namespace Stratosphere.Pages.Administration.AssetTypes.Services;

public class AssetTypeService(ILogger<AssetTypeService> logger, IDbRepository dbRepository) : IAssetTypeService
{
    private readonly ILogger<AssetTypeService> _logger = logger;
    private readonly IDbRepository _dbRepository = dbRepository;

    public async Task<List<AssetTypeVM>?> GetAssetTypes()
    {
        var dbVals = await _dbRepository.GetAllAssetTypes();

        if (dbVals is null || dbVals.Count == 0)
            return null;

        var retVal = ConvertToAssetTypeVM(dbVals);

        return retVal;
    }

    private static List<AssetTypeVM>? ConvertToAssetTypeVM(List<AssetType>? assetTypes)
    {
        if (assetTypes is null || assetTypes.Count == 0)
            return null;

        var retVal = new List<AssetTypeVM>();

        foreach (var assetType in assetTypes)
        {
            var assetTypeVM = ConvertToAssetTypeVM(assetType);

            if (assetTypeVM is null)
                continue;

            retVal.Add(assetTypeVM);
        }

        return retVal;
    }

    private static AssetTypeVM? ConvertToAssetTypeVM(AssetType? assetType)
    {
        if (assetType is null)
            return null;

        var retVal = new AssetTypeVM()
        {
            Name = assetType.Name,
            Description = assetType.Description
        };

        return retVal;
    }

    public async Task<AssetTypeVM?> GetAssetTypeByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var dbVal = await _dbRepository.GetAssetTypeByName(name);

        return ConvertToAssetTypeVM(dbVal);
    }

    public async Task<int> CreateAssetType(AssetTypeVM? assetType)
    {
        if (assetType is null)
            return 0;

        var dbVal = new AssetType()
        {
            AssetTypeId = Guid.NewGuid(),
            Name = assetType.Name,
            Description = assetType.Description
        };

        return await _dbRepository.CreateAssetType(dbVal);
    }

    public async Task<int> DeleteAssetTypeByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        return await _dbRepository.DeleteAssetTypeByName(name);
    }
}
