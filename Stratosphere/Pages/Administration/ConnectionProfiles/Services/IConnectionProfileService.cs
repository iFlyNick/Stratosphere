using Stratosphere.Pages.Administration.ConnectionProfiles.ViewModels;

namespace Stratosphere.Pages.Administration.ConnectionProfiles.Services;

public interface IConnectionProfileService
{
    Task<List<ConnectionProfileVM>?> GetConnectionProfiles();
    Task<ConnectionProfileVM?> GetConnectionProfileByName(string? name);
    Task<int> CreateConnectionProfile(ConnectionProfileVM? connectionProfile);
    Task<int> DeleteConnectionProfileByName(string? name);
}
