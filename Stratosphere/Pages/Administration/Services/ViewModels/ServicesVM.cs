using Stratosphere.Pages.Administration.ServiceTypes.ViewModels;

namespace Stratosphere.Pages.Administration.Services.ViewModels;

public class ServicesVM
{
    public List<ServiceVM>? Services { get; set; }
    public List<ServiceTypeVM>? Types { get; set; }
}
