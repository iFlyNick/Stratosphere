using Stratosphere.Data.Models;

namespace Stratosphere.Pages.Administration.Data;

public interface IDbRepository
{
    Task<List<ServiceType>?> GetAllServiceTypes();
    Task<int> CreateServiceType(ServiceType serviceType);
    Task<ServiceType?> GetServiceTypeByName(string? name);
    Task<int> DeleteServiceTypeByName(string? name);
    Task<List<Service>> GetAllServices();
    Task<int> CreateService(Service? service);
    Task<int> DeleteServiceByName(string? name);
}
