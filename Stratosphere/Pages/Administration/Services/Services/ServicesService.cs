using Stratosphere.Pages.Administration.Data;
using Stratosphere.Pages.Administration.Services.ViewModels;

namespace Stratosphere.Pages.Administration.Services.Services;

public class ServicesService(ILogger<ServicesService> logger, IDbRepository dbRepository) : IServicesService
{
    private readonly ILogger<ServicesService> _logger = logger;
    private readonly IDbRepository _dbRepository = dbRepository;

    public async Task<List<ServiceVM>?> GetServices()
    {
        return null;
    }
}
