using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Administration.Contacts.Services;
using Stratosphere.Pages.Administration.Contacts.ViewModels;

namespace Stratosphere.Pages.Administration.Contacts;

public class IndexModel(ILogger<IndexModel> logger, IContactService service) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IContactService _service = service;

    public async Task<IActionResult> OnGetContacts()
    {
        var contactsVM = new ContactsVM()
        {
            Contacts = await _service.GetContacts()
        };

        return Partial("Partials/_ContactPartial", contactsVM);
    }
}
