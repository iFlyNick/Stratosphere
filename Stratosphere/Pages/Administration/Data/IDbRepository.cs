using Stratosphere.Data.Models;

namespace Stratosphere.Pages.Administration.Data;

public interface IDbRepository
{
    Task<List<ServiceType>?> GetAllServiceTypes();
    Task<int> CreateServiceType(ServiceType serviceType);
}
