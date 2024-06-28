namespace Stratosphere.Pages.Maintenance.Models.DTOs;

public class MaintenanceRequestDetailDto
{
    public int MaintenanceRequestDetailId { get; set; }
    public Guid? MaintenanceRequestId { get; set; }
    public Guid? ServiceId { get; set; }
    public Guid? EnvironmentId { get; set; }
    public Guid? AssetId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? StopTime { get; set; }
    public DateTime? StartTime { get; set; }
    public bool IsSuccess { get; set; }
    public string? StatusMessage { get; set; }
}
