using Stratosphere.Pages.Maintenance.Models.DTOs;

namespace Stratosphere.Pages.Maintenance.Models;

public class MaintenanceModeRequest
{
    public MaintenanceRequestDto? Request { get; set; }
    public List<MaintenanceRequestDetailDto>? RequestDetails { get; set; }
    public List<MaintenanceRequestDetailHistoryDto>? HistoryDetails { get; set; }
}
