﻿namespace Stratosphere.Pages.Maintenance.Models.DTOs;

public class MaintenanceTemplateDto
{
    public Guid? MaintenanceTemplateId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}
