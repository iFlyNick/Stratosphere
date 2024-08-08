using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Administration.Services.Services;
using Stratosphere.Pages.Administration.Services.ViewModels;
using Stratosphere.Pages.Administration.ServiceTypes.Services;

namespace Stratosphere.Pages.Administration.Services;

public class IndexModel(ILogger<IndexModel> logger, IServicesService servicesService, IServiceTypeService serviceTypeService) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IServicesService _service = servicesService;
    private readonly IServiceTypeService _serviceTypeService = serviceTypeService;

    public async Task<IActionResult> OnGetServices()
    {
        var serviceVM = new ServicesVM()
        {
            Services = await _service.GetServices(),
            Types = await _serviceTypeService.GetServiceTypes()
        };

        return Partial("Partials/_ServicesPartial", serviceVM);
    }
}
