using Stratosphere.Data.Models;
using Stratosphere.Pages.Administration.Data;
using Stratosphere.Pages.Administration.ServiceTypes.ViewModels;

namespace Stratosphere.Pages.Administration.ServiceTypes.Services;

public class ServiceTypeService(ILogger<ServiceTypeService> logger, IDbRepository dbRepository) : IServiceTypeService
{
    private readonly ILogger<ServiceTypeService> _logger = logger;
    private readonly IDbRepository _dbRepository = dbRepository;

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
        var dbVal = new ServiceType()
        {
            ServiceTypeId = Guid.NewGuid(),
            Name = serviceType.Name
        };

        return await _dbRepository.CreateServiceType(dbVal);
    }

    private static List<ServiceTypeVM> MapServiceTypesToViewModels(List<ServiceType> serviceTypeList)
    {
        return serviceTypeList.Select(x => new ServiceTypeVM
        {
            Id = x.ServiceTypeId,
            Name = x.Name
        }).ToList();
    }
}
