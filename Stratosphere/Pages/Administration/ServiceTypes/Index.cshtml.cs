using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stratosphere.Pages.Administration.ServiceTypes.Services;
using Stratosphere.Pages.Administration.ServiceTypes.ViewModels;

namespace Stratosphere.Pages.Administration.ServiceTypes;

public class IndexModel(ILogger<IndexModel> logger, IServiceTypeService service) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IServiceTypeService _service = service;

    public async Task<IActionResult> OnGetServiceTypes()
    {
        var serviceTypesVM = new ServiceTypesVM()
        {
            ServiceTypes = await _service.GetServiceTypes()
        };

        return Partial("Partials/_ServiceTypePartial", serviceTypesVM);
    }

    public async Task<JsonResult> OnGetServiceTypesData()
    {
        var serviceTypesVM = new ServiceTypesVM()
        {
            ServiceTypes = await _service.GetServiceTypes()
        };

        return new JsonResult(new { success = true, dataList = serviceTypesVM.ServiceTypes });
    }

    public async Task<JsonResult> OnGetServiceType(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            _logger.LogInformation("Invalid service type name received for service type get");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received service type get request for {ServiceType}", name);

        var serviceType = await _service.GetServiceType(name);

        if (serviceType is null)
        {
            _logger.LogError("Failed to retrieve service type {ServiceType}", name);
            return new JsonResult(new { success = false });
        }

        return new JsonResult(new { success = true, serviceType });
    }

    public async Task<JsonResult> OnPostServiceType([FromBody] ServiceTypeVM serviceType)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("Invalid model state received for service type post");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received service type post request for {ServiceType}", serviceType.Name);

        var dbReturn = await _service.CreateServiceType(serviceType);

        if (dbReturn == 0)
        {
            _logger.LogError("Failed to create service type {ServiceType}", serviceType.Name);
            return new JsonResult(new { success = false });
        }

        return new JsonResult(new { success = true });
    }

    public async Task<JsonResult> OnPutServiceType([FromBody] ServiceTypeVM serviceType)
    {
        _logger.LogInformation("Received service type put request. has object: {test}", serviceType is null ? "nope" : "yep");

        return new JsonResult(new { success = true });
    }

    public async Task<JsonResult> OnDeleteServiceType(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            _logger.LogInformation("Invalid service type name received for service type delete");
            return new JsonResult(new { success = false });
        }

        _logger.LogInformation("Received service type delete request for {ServiceType}", name);

        await _service.DeleteServiceTypeByName(name);

        return new JsonResult(new { success = true });
    }
}
