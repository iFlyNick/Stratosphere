using Stratosphere.Pages.Administration.Environments.ViewModels;
using EnvironmentDto = Stratosphere.Data.Models.EnvironmentDto;

namespace Stratosphere.Pages.Administration.Environments.Services;

public interface IEnvironmentService
{
    Task<List<EnvironmentVM>?> GetEnvironments();
    Task<EnvironmentDto?> GetEnvironmentByName(string? name);
    Task<int> CreateEnvironment(EnvironmentVM? environment);
    Task<int> DeleteEnvironmentByName(string? name);
}
