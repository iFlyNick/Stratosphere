using Stratosphere.Pages.Administration.Environments.ViewModels;
using Environment = Stratosphere.Data.Models.Environment;

namespace Stratosphere.Pages.Administration.Environments.Services;

public interface IEnvironmentService
{
    Task<List<EnvironmentVM>?> GetEnvironments();
    Task<Environment?> GetEnvironmentByName(string? name);
    Task<int> CreateEnvironment(EnvironmentVM? environment);
    Task<int> DeleteEnvironmentByName(string? name);
}
