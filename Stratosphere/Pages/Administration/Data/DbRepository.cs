using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Stratosphere.Data;
using Stratosphere.Data.Models;
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

    public async Task<List<ServiceType>?> GetAllServiceTypes()
    {
        var serviceTypes = _cacheService.GetCacheEntry(_serviceTypesCacheKey) as List<ServiceType>;

        if (serviceTypes is not null)
            return serviceTypes;

        var records = await _dbContext.ServiceType.ToListAsync();

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
        var serviceTypes = await _dbContext.ServiceType.ToListAsync();
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

        var record = await _dbContext.ServiceType.FirstOrDefaultAsync(x => x.Name == name);

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
        var serviceTypes = await _dbContext.ServiceType.ToListAsync();
        _cacheService.RefreshCacheEntry(_serviceTypesCacheKey, serviceTypes);

        return records;
    }

    public async Task<List<Service>> GetAllServices()
    {
        var services = _cacheService.GetCacheEntry(_servicesCacheKey) as List<Service>;

        if (services is not null)
                return services;

        var records = await _dbContext.Service.Include(s => s.ServiceType).ToListAsync();

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

        await _dbContext.Service.AddAsync(service);

        var records = await _dbContext.SaveChangesAsync();

        if (records == 0)
        {
            _logger.LogInformation("Failed to create service {Service}", service.Name);
            return records;
        }

        _logger.LogDebug("Updating services cache");
        var services = await _dbContext.Service.ToListAsync();
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

        var record = await _dbContext.Service.FirstOrDefaultAsync(x => x.Name == name);

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
        var services = await _dbContext.Service.ToListAsync();
        _cacheService.RefreshCacheEntry(_servicesCacheKey, services);

        return records;
    }

    public async Task<List<Environment>?> GetAllEnvironments()
    {
        var environments = _cacheService.GetCacheEntry(_environmentsCacheKey) as List<Environment>;

        if (environments is not null)
            return environments;

        var records = await _dbContext.Environment.ToListAsync();

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

        var record = await _dbContext.Environment.FirstOrDefaultAsync(x => x.Name == name);

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
        var environments = await _dbContext.Environment.ToListAsync();
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
        var environments = await _dbContext.Environment.ToListAsync();
        _cacheService.RefreshCacheEntry(_environmentsCacheKey, environments);

        return records;
    }
}
