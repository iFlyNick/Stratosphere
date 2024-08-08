using Stratosphere.Pages.Administration.Users.ViewModels;

namespace Stratosphere.Pages.Administration.Users.Services;

public interface IUserService
{
    Task<List<UserVM>?> GetUsers();
}
