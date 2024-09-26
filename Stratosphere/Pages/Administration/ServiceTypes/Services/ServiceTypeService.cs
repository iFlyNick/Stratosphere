using Stratosphere.Data.Models;
using Stratosphere.Pages.Administration.Data;
using Stratosphere.Pages.Administration.ServiceTypes.ViewModels;

namespace Stratosphere.Pages.Administration.ServiceTypes.Services;

public class ServiceTypeService(ILogger<ServiceTypeService> logger, IDbRepository dbRepository) : IServiceTypeService
{
    private readonly ILogger<ServiceTypeService> _logger = logger;
    private readonly IDbRepository _dbRepository = dbRepository;

    public async Task<ServiceTypeVM?> GetServiceType(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var dbRecord = await _dbRepository.GetServiceTypeByName(name);

        var retVal = MapServiceTypesToViewModels(dbRecord);

        return retVal;
    }

    public async Task<int> DeleteServiceTypeByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        var rows = await _dbRepository.DeleteServiceTypeByName(name);

        return rows;
    }

    public async Task<List<ServiceTypeVM>> GetServiceTypes()
    {
        var dbRecords = await _dbRepository.GetAllServiceTypes();

        if (dbRecords == null)
        {
            _logger.LogWarning("No service types found in the database");
            return [];
        }

        var serviceTypeVMs = MapServiceTypesToViewModels(dbRecords);

        return serviceTypeVMs ?? [];
    }

    public async Task<int> CreateServiceType(ServiceTypeVM serviceType)
    {
        var dbVal = new ServiceTypeDto()
        {
            ServiceTypeId = Guid.NewGuid(),
            Name = serviceType.Name
        };

        return await _dbRepository.CreateServiceType(dbVal);
    }

    private static List<ServiceTypeVM> MapServiceTypesToViewModels(List<ServiceTypeDto> serviceTypeList)
    {
        return serviceTypeList.Select(x => new ServiceTypeVM
        {
            Id = x.ServiceTypeId,
            Name = x.Name
        }).ToList();
    }

    private static ServiceTypeVM? MapServiceTypesToViewModels(ServiceTypeDto? serviceType)
    {
        if (serviceType is null)
            return null;

        return new ServiceTypeVM()
        {
            Id = serviceType.ServiceTypeId,
            Name = serviceType.Name
        };
    }
}
