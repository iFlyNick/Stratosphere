using Stratosphere.Data.Models;
using EnvironmentDto = Stratosphere.Data.Models.EnvironmentDto;

namespace Stratosphere.Pages.Administration.Data;

public interface IDbRepository
{
    Task<List<ServiceTypeDto>?> GetAllServiceTypes();
    Task<ServiceTypeDto?> GetServiceTypeByName(string? name);
    Task<int> CreateServiceType(ServiceTypeDto serviceType);
    Task<int> DeleteServiceTypeByName(string? name);

    Task<List<ServiceDto>> GetAllServices();
    Task<ServiceDto?> GetServiceByName(string? name);
    Task<int> CreateService(ServiceDto? service);
    Task<int> DeleteServiceByName(string? name);

    Task<List<EnvironmentDto>?> GetAllEnvironments();
    Task<EnvironmentDto?> GetEnvironmentByName(string? name);
    Task<int> CreateEnvironment(EnvironmentDto? environment);
    Task<int> DeleteEnvironmentByName(string? name);

    Task<List<AssetTypeDto>?> GetAllAssetTypes();
    Task<AssetTypeDto?> GetAssetTypeByName(string? name);
    Task<int> CreateAssetType(AssetTypeDto? assetType);
    Task<int> DeleteAssetTypeByName(string? name);

    Task<List<ConnectionProfileDto>?> GetAllConnectionProfiles();
    Task<ConnectionProfileDto?> GetConnectionProfileByName(string? name);
    Task<int> CreateConnectionProfile(ConnectionProfileDto? connectionProfile);
    Task<int> DeleteConnectionProfileByName(string? name);
}
