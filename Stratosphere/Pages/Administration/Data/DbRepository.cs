using Microsoft.EntityFrameworkCore;
using Stratosphere.Data;
using Stratosphere.Data.Models;

namespace Stratosphere.Pages.Administration.Data;

public class DbRepository(ILogger<DbRepository> logger, StratosphereContext dbContext) : IDbRepository
{
    private readonly ILogger<DbRepository> _logger = logger;
    private readonly StratosphereContext _dbContext = dbContext;

    private const string _defaultDbUser = "StratosphereAdmin";

    public async Task<List<ServiceType>?> GetAllServiceTypes()
    {
        var records = await _dbContext.ServiceType.ToListAsync();

        _logger.LogDebug("Retrieved {Count} service types from the database", records.Count);

        return records;
    }

    public async Task<int> CreateServiceType(ServiceType serviceType)
    {
        serviceType.CreatedDate = DateTime.UtcNow;
        serviceType.CreatedBy = _defaultDbUser;

        await _dbContext.ServiceType.AddAsync(serviceType);

        return await _dbContext.SaveChangesAsync();
    }
}
