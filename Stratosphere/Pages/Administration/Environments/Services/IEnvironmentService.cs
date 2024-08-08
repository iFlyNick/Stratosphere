using Stratosphere.Pages.Administration.Environments.ViewModels;

namespace Stratosphere.Pages.Administration.Environments.Services;

public interface IEnvironmentService
{
    Task<List<EnvironmentVM>?> GetEnvironments();
}
