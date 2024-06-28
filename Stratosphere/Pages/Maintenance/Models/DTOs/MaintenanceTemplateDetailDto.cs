namespace Stratosphere.Pages.Maintenance.Models.DTOs;

public class MaintenanceTemplateDetailDto
{
    public Guid? MaintenanceTemplateId { get; set; }
    public Guid? ServiceId { get; set; }
    public Guid? EnvironmentId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int StartOrder { get; set; }
    public int StopOrder { get; set; }
    public bool WaitForQueueClearOnStart { get; set; }
    public bool WaitForQueueClearOnStop { get; set; }
}
