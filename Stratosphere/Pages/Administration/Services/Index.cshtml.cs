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

    public async Task<IActionResult> OnGetServicesData()
    {
        var serviceVM = new ServicesVM()
        {
            Services = await _service.GetServices()
        };

        return new JsonResult(new { success = true, dataList = serviceVM.Services });
    }

    public async Task<JsonResult> OnPostService([FromBody] ServiceVM service)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("Invalid model state received for service post");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received service post request for {service}", service.Name);

        var dbReturn = await _service.CreateService(service);

        if (dbReturn == 0)
        {
            _logger.LogError("Failed to create service {service}", service.Name);
            return new JsonResult(new { success = false });
        }

        return new JsonResult(new { success = true });
    }

    public async Task<JsonResult> OnPutServiceType([FromBody] ServiceVM service)
    {
        _logger.LogInformation("Received service put request. has object: {test}", service is null ? "nope" : "yep");

        return new JsonResult(new { success = true });
    }

    public async Task<JsonResult> OnDeleteService(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            _logger.LogInformation("Invalid service name received for service delete");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received service delete request for {service}", name);

        await _service.DeleteServiceByName(name);

        return new JsonResult(new { success = true });
    }
}
