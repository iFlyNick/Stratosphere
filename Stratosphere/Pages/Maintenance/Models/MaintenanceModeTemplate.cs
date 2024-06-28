using Stratosphere.Pages.Maintenance.Models.DTOs;

namespace Stratosphere.Pages.Maintenance.Models;

public class MaintenanceModeTemplate
{
    public MaintenanceTemplateDto? Template { get; set; }
    public List<MaintenanceTemplateDetailDto>? TemplateDetails { get; set; }
}
