using Stratosphere.Pages.Administration.Environments.ViewModels;

namespace Stratosphere.Pages.Administration.Environments.Services;

public class EnvironmentService : IEnvironmentService
{
    public async Task<List<EnvironmentVM>?> GetEnvironments()
    {
        var retVal = new List<EnvironmentVM>();

        return retVal;
    }
}
