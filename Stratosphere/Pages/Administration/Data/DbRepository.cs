using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Stratosphere.Data;
using Stratosphere.Data.Models;

namespace Stratosphere.Pages.Administration.Data;

public class DbRepository(ILogger<DbRepository> logger, StratosphereContext dbContext, IMemoryCache cache) : IDbRepository
{
    private readonly ILogger<DbRepository> _logger = logger;
    private readonly StratosphereContext _dbContext = dbContext;
    private readonly IMemoryCache _cache = cache;

    private const string _defaultDbUser = "StratosphereAdmin";
    private const string _serviceTypesCacheKey = "ServiceTypes";
    private const string _servicesCacheKey = "Services";

    public async Task<List<ServiceType>?> GetAllServiceTypes()
    {
        if (_cache.TryGetValue(_serviceTypesCacheKey, out List<ServiceType>? serviceTypes))
            if (serviceTypes is not null)
                return serviceTypes;

        var records = await _dbContext.ServiceType.ToListAsync();

        _logger.LogDebug("Retrieved {Count} service types from the database", records.Count);

        _cache.Set(_serviceTypesCacheKey, records);

        return records ?? [];
    }

    public async Task<int> CreateServiceType(ServiceType serviceType)
    {
        serviceType.CreatedDate = DateTime.UtcNow;
        serviceType.CreatedBy = _defaultDbUser;

        await _dbContext.ServiceType.AddAsync(serviceType);

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<ServiceType?> GetServiceTypeByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        if (_cache.TryGetValue(_serviceTypesCacheKey, out List<ServiceType>? serviceTypes))
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

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Service>> GetAllServices()
    {
        if (_cache.TryGetValue(_servicesCacheKey, out List<Service>? services))
            if (services is not null)
                return services;

        var records = await _dbContext.Service.Include(s => s.ServiceType).ToListAsync();

        _logger.LogDebug("Retrieved {Count} services from the database", records.Count);

        _cache.Set(_servicesCacheKey, records);

        return records ?? [];
    }

    public async Task<int> CreateService(Service? service)
    {
        if (service is null)
            return 0;

        service.CreatedDate = DateTime.UtcNow;
        service.CreatedBy = _defaultDbUser;

        await _dbContext.Service.AddAsync(service);

        return await _dbContext.SaveChangesAsync();
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

        return await _dbContext.SaveChangesAsync();
    }
}
