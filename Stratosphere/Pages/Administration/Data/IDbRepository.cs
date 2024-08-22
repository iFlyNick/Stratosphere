using Stratosphere.Data.Models;
using Environment = Stratosphere.Data.Models.Environment;

namespace Stratosphere.Pages.Administration.Data;

public interface IDbRepository
{
    Task<List<ServiceType>?> GetAllServiceTypes();
    Task<ServiceType?> GetServiceTypeByName(string? name);
    Task<int> CreateServiceType(ServiceType serviceType);
    Task<int> DeleteServiceTypeByName(string? name);

    Task<List<Service>> GetAllServices();
    Task<Service?> GetServiceByName(string? name);
    Task<int> CreateService(Service? service);
    Task<int> DeleteServiceByName(string? name);

    Task<List<Environment>?> GetAllEnvironments();
    Task<Environment?> GetEnvironmentByName(string? name);
    Task<int> CreateEnvironment(Environment? environment);
    Task<int> DeleteEnvironmentByName(string? name);

    Task<List<AssetType>?> GetAllAssetTypes();
    Task<AssetType?> GetAssetTypeByName(string? name);
    Task<int> CreateAssetType(AssetType? assetType);
    Task<int> DeleteAssetTypeByName(string? name);
}
