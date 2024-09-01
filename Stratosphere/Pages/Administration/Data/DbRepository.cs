using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Stratosphere.Data;
using Stratosphere.Data.Models;
using Stratosphere.Pages.Administration.AssetTypes.ViewModels;
using Stratosphere.Services.Cache;
using System;
using Environment = Stratosphere.Data.Models.Environment;

namespace Stratosphere.Pages.Administration.Data;

public class DbRepository(ILogger<DbRepository> logger, StratosphereContext dbContext, ICacheService cacheService) : IDbRepository
{
    private readonly ILogger<DbRepository> _logger = logger;
    private readonly StratosphereContext _dbContext = dbContext;
    private readonly ICacheService _cacheService = cacheService;

    private const string _defaultDbUser = "StratosphereAdmin";
    private const string _serviceTypesCacheKey = "ServiceTypes";
    private const string _servicesCacheKey = "Services";
    private const string _environmentsCacheKey = "Environments";
    private const string _assetTypesCacheKey = "AssetTypes";
    private const string _connectionProfilesCacheKey = "ConnectionProfiles";

    public async Task<List<ServiceType>?> GetAllServiceTypes()
    {
        var serviceTypes = _cacheService.GetCacheEntry(_serviceTypesCacheKey) as List<ServiceType>;

        if (serviceTypes is not null)
            return serviceTypes;

        var records = await _dbContext.ServiceType.AsNoTracking().ToListAsync();

        _logger.LogDebug("Retrieved {Count} service types from the database", records.Count);

        _cacheService.AddCacheEntry(_serviceTypesCacheKey, records);

        return records ?? [];
    }

    public async Task<int> CreateServiceType(ServiceType serviceType)
    {
        serviceType.CreatedDate = DateTime.UtcNow;
        serviceType.CreatedBy = _defaultDbUser;

        await _dbContext.ServiceType.AddAsync(serviceType);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to create service type {ServiceType}", serviceType.Name);
            return records;
        }

        _logger.LogDebug("Updating service types cache");
        var serviceTypes = await _dbContext.ServiceType.AsNoTracking().ToListAsync();
        _cacheService.RefreshCacheEntry(_serviceTypesCacheKey, serviceTypes);

        return records;
    }

    public async Task<ServiceType?> GetServiceTypeByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var serviceTypes = _cacheService.GetCacheEntry(_serviceTypesCacheKey) as List<ServiceType>;

        if (serviceTypes is not null)
            return serviceTypes.FirstOrDefault(x => x.Name == name);

        var record = await _dbContext.ServiceType.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);

        return record;
    }

    public async Task<int> DeleteServiceTypeByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        var record = await _dbContext.ServiceType.FirstOrDefaultAsync(x => x.Name == name);

        if (record is null)
            return 0;

        _logger.LogInformation("Deleting service type {ServiceType}", name);
        _dbContext.ServiceType.Remove(record);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to delete service type {ServiceType}", record.Name);
            return records;
        }

        _logger.LogDebug("Updating service types cache");
        var serviceTypes = await _dbContext.ServiceType.AsNoTracking().ToListAsync();
        _cacheService.RefreshCacheEntry(_serviceTypesCacheKey, serviceTypes);

        return records;
    }

    public async Task<List<Service>> GetAllServices()
    {
        var services = _cacheService.GetCacheEntry(_servicesCacheKey) as List<Service>;

        if (services is not null)
                return services;

        var records = await _dbContext.Service.AsNoTracking().Include(s => s.ServiceType).ToListAsync();

        _logger.LogDebug("Retrieved {Count} services from the database", records.Count);

        _cacheService.AddCacheEntry(_servicesCacheKey, records);

        return records ?? [];
    }

    public async Task<int> CreateService(Service? service)
    {
        if (service is null)
            return 0;

        service.CreatedDate = DateTime.UtcNow;
        service.CreatedBy = _defaultDbUser;

        //value is cached above this layer so need to force add it for ef to not try and re-insert it
        if (service.ServiceType is not null)
            _dbContext.ServiceType.Attach(service.ServiceType);

        await _dbContext.Service.AddAsync(service);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to create service {Service}", service.Name);
            return records;
        }

        _logger.LogDebug("Updating services cache");
        var services = await _dbContext.Service.AsNoTracking().ToListAsync();
        _cacheService.RefreshCacheEntry(_servicesCacheKey, services);

        return records;
    }

    public async Task<Service?> GetServiceByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var services = _cacheService.GetCacheEntry(_servicesCacheKey) as List<Service>;

        if (services is not null)
            return services.FirstOrDefault(x => x.Name == name);

        var record = await _dbContext.Service.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);

        return record;
    }

    public async Task<int> DeleteServiceByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        var record = await _dbContext.Service.FirstOrDefaultAsync(x => x.Name == name);

        if (record is null)
            return 0;

        _logger.LogInformation("Deleting service {Service}", name);
        _dbContext.Service.Remove(record);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to delete service {Service}", record.Name);
            return records;
        }

        _logger.LogDebug("Updating services cache");
        var services = await _dbContext.Service.AsNoTracking().ToListAsync();
        _cacheService.RefreshCacheEntry(_servicesCacheKey, services);

        return records;
    }

    public async Task<List<Environment>?> GetAllEnvironments()
    {
        var environments = _cacheService.GetCacheEntry(_environmentsCacheKey) as List<Environment>;

        if (environments is not null)
            return environments;

        var records = await _dbContext.Environment.AsNoTracking().ToListAsync();

        _logger.LogDebug("Retrieved {Count} environments from the database", records.Count);

        _cacheService.AddCacheEntry(_environmentsCacheKey, records);

        return records ?? [];
    }

    public async Task<Environment?> GetEnvironmentByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var environments = _cacheService.GetCacheEntry(_environmentsCacheKey) as List<Environment>;

        if (environments is not null)
            return environments.FirstOrDefault(x => x.Name == name);

        var record = await _dbContext.Environment.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);

        return record;
    }

    public async Task<int> CreateEnvironment(Environment? environment)
    {
        if (environment is null)
            return 0;

        environment.CreatedDate = DateTime.UtcNow;
        environment.CreatedBy = _defaultDbUser;

        await _dbContext.Environment.AddAsync(environment);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to create environment {environment}", environment.Name);
            return records;
        }

        _logger.LogDebug("Updating environments cache");
        var environments = await _dbContext.Environment.AsNoTracking().ToListAsync();
        _cacheService.RefreshCacheEntry(_environmentsCacheKey, environments);

        return records;
    }

    public async Task<int> DeleteEnvironmentByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        var record = await _dbContext.Environment.FirstOrDefaultAsync(x => x.Name == name);

        if (record is null)
            return 0;

        _logger.LogInformation("Deleting environment {name}", name);
        _dbContext.Environment.Remove(record);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to delete environment {environment}", record.Name);
            return records;
        }

        _logger.LogDebug("Updating environments cache");
        var environments = await _dbContext.Environment.AsNoTracking().ToListAsync();
        _cacheService.RefreshCacheEntry(_environmentsCacheKey, environments);

        return records;
    }

    public async Task<List<AssetType>?> GetAllAssetTypes()
    {
        var assetTypes = _cacheService.GetCacheEntry(_assetTypesCacheKey) as List<AssetType>;

        if (assetTypes is not null)
            return assetTypes;

        var records = await _dbContext.AssetType.AsNoTracking().ToListAsync();

        _logger.LogDebug("Retrieved {Count} asset types from the database", records.Count);

        _cacheService.AddCacheEntry(_assetTypesCacheKey, records);

        return records ?? [];
    }

    public async Task<AssetType?> GetAssetTypeByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var assetTypes = _cacheService.GetCacheEntry(_assetTypesCacheKey) as List<AssetType>;

        if (assetTypes is not null)
            return assetTypes.FirstOrDefault(x => x.Name == name);

        var record = await _dbContext.AssetType.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);

        return record;
    }

    public async Task<int> CreateAssetType(AssetType? assetType)
    {
        if (assetType is null)
            return 0;

        assetType.CreatedDate = DateTime.UtcNow;
        assetType.CreatedBy = _defaultDbUser;

        await _dbContext.AssetType.AddAsync(assetType);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to create asset type {assetType}", assetType.Name);
            return records;
        }

        _logger.LogDebug("Updating asset types cache");
        var assetTypes = await _dbContext.AssetType.AsNoTracking().ToListAsync();
        _cacheService.RefreshCacheEntry(_assetTypesCacheKey, assetTypes);

        return records;
    }

    public async Task<int> DeleteAssetTypeByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        var record = await _dbContext.AssetType.FirstOrDefaultAsync(x => x.Name == name);

        if (record is null)
            return 0;

        _logger.LogInformation("Deleting asset type {name}", name);
        _dbContext.AssetType.Remove(record);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to delete asset type {assetType}", record.Name);
            return records;
        }

        _logger.LogDebug("Updating asset types cache");
        var assetTypes = await _dbContext.AssetType.AsNoTracking().ToListAsync();
        _cacheService.RefreshCacheEntry(_assetTypesCacheKey, assetTypes);

        return records;
    }

    public async Task<List<ConnectionProfile>?> GetAllConnectionProfiles()
    {
        var connectionProfiles = _cacheService.GetCacheEntry(_connectionProfilesCacheKey) as List<ConnectionProfile>;

        if (connectionProfiles is not null)
            return connectionProfiles;

        var records = await _dbContext.ConnectionProfile.AsNoTracking().ToListAsync();

        _logger.LogDebug("Retrieved {Count} connection profiles from the database", records.Count);

        _cacheService.AddCacheEntry(_connectionProfilesCacheKey, records);

        return records ?? [];
    }

    public async Task<ConnectionProfile?> GetConnectionProfileByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var connectionProfiles = _cacheService.GetCacheEntry(_connectionProfilesCacheKey) as List<ConnectionProfile>;

        if (connectionProfiles is not null)
            return connectionProfiles.FirstOrDefault(x => x.Name == name);

        var record = await _dbContext.ConnectionProfile.AsNoTracking().FirstOrDefaultAsync(x => x.Name == name);

        return record;
    }

    public async Task<int> CreateConnectionProfile(ConnectionProfile? connectionProfile)
    {
        if (connectionProfile is null)
            return 0;

        connectionProfile.CreatedDate = DateTime.UtcNow;
        connectionProfile.CreatedBy = _defaultDbUser;

        await _dbContext.ConnectionProfile.AddAsync(connectionProfile);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to create connection profile {connectionProfile}", connectionProfile.Name);
            return records;
        }

        _logger.LogDebug("Updating connection profiles cache");
        var connectionProfiles = await _dbContext.ConnectionProfile.AsNoTracking().ToListAsync();
        _cacheService.RefreshCacheEntry(_connectionProfilesCacheKey, connectionProfiles);

        return records;
    }

    public async Task<int> DeleteConnectionProfileByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        var record = await _dbContext.ConnectionProfile.FirstOrDefaultAsync(x => x.Name == name);

        if (record is null)
            return 0;

        _logger.LogInformation("Deleting connection profile {name}", name);
        _dbContext.ConnectionProfile.Remove(record);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to delete connection profile {connectionProfile}", record.Name);
            return records;
        }

        _logger.LogDebug("Updating connection profiles cache");
        var connectionProfiles = await _dbContext.ConnectionProfile.AsNoTracking().ToListAsync();
        _cacheService.RefreshCacheEntry(_connectionProfilesCacheKey, connectionProfiles);

        return records;
    }
}
