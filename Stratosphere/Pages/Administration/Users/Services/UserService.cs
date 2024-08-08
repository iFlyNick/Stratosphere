using Stratosphere.Pages.Administration.Users.ViewModels;

namespace Stratosphere.Pages.Administration.Users.Services;

public class UserService : IUserService
{
    public async Task<List<UserVM>?> GetUsers()
    {
        var retVal = new List<UserVM>();

        return retVal;
    }
}
