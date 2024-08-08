using Stratosphere.Pages.Administration.ServiceTypes.ViewModels;
using System.Xml.Linq;

namespace Stratosphere.Pages.Administration.ServiceTypes.Services;

public interface IServiceTypeService
{
    Task<List<ServiceTypeVM>> GetServiceTypes();
    Task<int> CreateServiceType(ServiceTypeVM serviceType);
    Task<ServiceTypeVM?> GetServiceType(string? name);
    Task<int> DeleteServiceTypeByName(string? name);
}
