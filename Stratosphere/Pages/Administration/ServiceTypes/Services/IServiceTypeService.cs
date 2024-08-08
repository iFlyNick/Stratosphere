using Stratosphere.Pages.Administration.ServiceTypes.ViewModels;

namespace Stratosphere.Pages.Administration.ServiceTypes.Services;

public interface IServiceTypeService
{
    Task<List<ServiceTypeVM>> GetServiceTypes();
    Task<int> CreateServiceType(ServiceTypeVM serviceType);
}
