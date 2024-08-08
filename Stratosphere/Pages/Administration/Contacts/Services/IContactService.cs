using Stratosphere.Pages.Administration.Contacts.ViewModels;

namespace Stratosphere.Pages.Administration.Contacts.Services;

public interface IContactService
{
    Task<List<ContactVM>?> GetContacts();
}
