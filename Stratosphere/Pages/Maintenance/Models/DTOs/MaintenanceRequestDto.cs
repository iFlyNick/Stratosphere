namespace Stratosphere.Pages.Maintenance.Models.DTOs;

public class MaintenanceRequestDto
{
    public Guid? MaintenanceRequestId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Description { get; set; }
    public string? CompletionNote { get; set; }
    public DateTime? ScheduledStartTime { get; set; }
    public DateTime? ScheduledEndTime { get; set; }
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }
    public bool AutomaticStartEnabled { get; set; }
    public bool AutomaticEndEnabled { get; set; }
}
