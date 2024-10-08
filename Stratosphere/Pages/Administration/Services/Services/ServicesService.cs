﻿using Stratosphere.Data.Models;
using Stratosphere.Pages.Administration.Data;
using Stratosphere.Pages.Administration.Services.ViewModels;

namespace Stratosphere.Pages.Administration.Services.Services;

public class ServicesService(ILogger<ServicesService> logger, IDbRepository dbRepository) : IServicesService
{
    private readonly ILogger<ServicesService> _logger = logger;
    private readonly IDbRepository _dbRepository = dbRepository;

    public async Task<List<ServiceVM>?> GetServices()
    {
        var dbRecords = await _dbRepository.GetAllServices();

        if (dbRecords is null)
        {
            _logger.LogWarning("No services found in the database");
            return [];
        }

        var serviceVMs = MapServicesToViewModels(dbRecords);

        return serviceVMs ?? [];
    }

    public async Task<ServiceVM?> GetServiceByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var dbRecord = await _dbRepository.GetServiceByName(name);

        if (dbRecord is null)
            return null;

        var retVal = new ServiceVM()
        {
            Name = dbRecord.Name,
            Description = dbRecord.Description,
            Type = dbRecord.ServiceType?.Name
        };

        return retVal;
    }

    public async Task<int> CreateService(ServiceVM? service)
    {
        if (service is null)
            return 0;

        var serviceType = await _dbRepository.GetServiceTypeByName(service.Type);

        var dbVal = new ServiceDto()
        {
            ServiceId = Guid.NewGuid(),
            Name = service.Name,
            Description = service.Description,
            ServiceType = serviceType,
            ServiceTypeId = serviceType?.ServiceTypeId
        };

        return await _dbRepository.CreateService(dbVal);
    }

    private static List<ServiceVM>? MapServicesToViewModels(List<ServiceDto>? services)
    {
        if (services is null || services.Count == 0)
            return null;

        var retList = new List<ServiceVM>();

        foreach (var service in services)
        {
            var serviceVM = new ServiceVM()
            {
                Name = service.Name,
                Description = service.Description,
                Type = service.ServiceType?.Name
            };

            retList.Add(serviceVM);
        }

        return retList;
    }

    public async Task<int> DeleteServiceByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        var rows = await _dbRepository.DeleteServiceByName(name);

        return rows;
    }
}
