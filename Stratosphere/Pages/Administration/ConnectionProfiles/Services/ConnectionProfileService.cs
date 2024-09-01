using Stratosphere.Data.Models;
using Stratosphere.Pages.Administration.ConnectionProfiles.ViewModels;
using Stratosphere.Pages.Administration.Data;

namespace Stratosphere.Pages.Administration.ConnectionProfiles.Services;

public class ConnectionProfileService(ILogger<ConnectionProfileService> logger, IDbRepository dbRepository) : IConnectionProfileService
{
    private readonly ILogger<ConnectionProfileService> _logger = logger;
    private readonly IDbRepository _dbRepository = dbRepository;

    public async Task<List<ConnectionProfileVM>?> GetConnectionProfiles()
    {
        var dbVals = await _dbRepository.GetAllConnectionProfiles();

        if (dbVals is null || dbVals.Count == 0)
            return null;

        var retVal = ConvertToConnectionProfileVM(dbVals);

        return retVal;
    }

    private static List<ConnectionProfileVM>? ConvertToConnectionProfileVM(List<ConnectionProfile>? connectionProfiles)
    {
        if (connectionProfiles is null || connectionProfiles.Count == 0)
            return null;

        var retVal = new List<ConnectionProfileVM>();

        foreach (var connectionProfile in connectionProfiles)
        {
            var connectionProfileVM = ConvertToConnectionProfileVM(connectionProfile);

            if (connectionProfileVM is null)
                continue;

            retVal.Add(connectionProfileVM);
        }

        return retVal;
    }

    private static ConnectionProfileVM? ConvertToConnectionProfileVM(ConnectionProfile? connectionProfile)
    {
        if (connectionProfile is null)
            return null;

        var retVal = new ConnectionProfileVM()
        {
            Name = connectionProfile.Name,
            Username = connectionProfile.UserName,
            Password = connectionProfile.Password
        };

        return retVal;
    }

    public async Task<ConnectionProfileVM?> GetConnectionProfileByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return null;

        var dbVal = await _dbRepository.GetConnectionProfileByName(name);

        return ConvertToConnectionProfileVM(dbVal);
    }

    public async Task<int> CreateConnectionProfile(ConnectionProfileVM? connectionProfile)
    {
        if (connectionProfile is null)
            return 0;

        var dbVal = new ConnectionProfile()
        {
            ConnectionProfileId = Guid.NewGuid(),
            Name = connectionProfile.Name,
            UserName = connectionProfile.Username,
            Password = connectionProfile.Password
        };

        return await _dbRepository.CreateConnectionProfile(dbVal);
    }

    public async Task<int> DeleteConnectionProfileByName(string? name)
    {
        if (string.IsNullOrEmpty(name))
            return 0;

        return await _dbRepository.DeleteConnectionProfileByName(name);
    }
}
