using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Administration.Users.Services;
using Stratosphere.Pages.Administration.Users.ViewModels;

namespace Stratosphere.Pages.Administration.Users;

public class IndexModel(ILogger<IndexModel> logger, IUserService service) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IUserService _service = service;

    public async Task<IActionResult> OnGetUsers()
    {
        var usersVM = new UsersVM()
        {
            Users = await _service.GetUsers()
        };

        return Partial("Partials/_UserPartial", usersVM);
    }
}
