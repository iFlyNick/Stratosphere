using Stratosphere.Pages.Administration.Data;
using Stratosphere.Pages.Administration.Environments.ViewModels;
using Environment = Stratosphere.Data.Models.Environment;

namespace Stratosphere.Pages.Administration.Environments.Services;

public class EnvironmentService(ILogger<EnvironmentService> logger, IDbRepository dbRepository) : IEnvironmentService
{
    private readonly ILogger<EnvironmentService> _logger = logger;
    private readonly IDbRepository _dbRepository = dbRepository;

    public async Task<List<EnvironmentVM>?> GetEnvironments()
    {
        var dbEnvs = await _dbRepository.GetAllEnvironments();

        if (dbEnvs is null || dbEnvs.Count == 0)
            return null;

        var retVal = ConvertToEnvironmentVM(dbEnvs);

        return retVal;
    }

    private static List<EnvironmentVM>? ConvertToEnvironmentVM(List<Environment>? environments)
    {
        if (environments is null || environments.Count == 0)
            return null;

        var retVal = new List<EnvironmentVM>();

        foreach (var environment in environments)
        {
            if (environment is null)
                continue;

            var env = new EnvironmentVM()
            {
                Name = environment.Name,
                Description = environment.Description
            };

            if (env is null)
                continue;

            retVal.Add(env);
        }

        return retVal;
    }

    public async Task<Environment?> GetEnvironmentByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        return await _dbRepository.GetEnvironmentByName(name);
    }

    public async Task<int> CreateEnvironment(EnvironmentVM? environment)
    {
        if (environment is null)
            return 0;

        var dbVal = new Environment()
        {
            EnvironmentId = Guid.NewGuid(),
            Name = environment.Name,
            Description = environment.Description
        };

        return await _dbRepository.CreateEnvironment(dbVal);
    }

    public async Task<int> DeleteEnvironmentByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        return await _dbRepository.DeleteEnvironmentByName(name);
    }
}
