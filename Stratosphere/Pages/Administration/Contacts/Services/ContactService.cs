using Stratosphere.Pages.Administration.Contacts.ViewModels;

namespace Stratosphere.Pages.Administration.Contacts.Services;

public class ContactService : IContactService
{
    public async Task<List<ContactVM>?> GetContacts()
    {
        var retVal = new List<ContactVM>();

        return retVal;
    }
}
