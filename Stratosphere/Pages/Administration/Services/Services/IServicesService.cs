using Stratosphere.Pages.Administration.Services.ViewModels;
using Stratosphere.Pages.Administration.ServiceTypes.ViewModels;

namespace Stratosphere.Pages.Administration.Services.Services;

public interface IServicesService
{
    Task<List<ServiceVM>?> GetServices();
    Task<int> CreateService(ServiceVM? service);
    Task<int> DeleteServiceByName(string? name);
}
