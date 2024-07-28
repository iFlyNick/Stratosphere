using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class MaintenanceRequest
{
    //should these include a group concept for searching?
    [Required] public Guid? MaintenanceRequestId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [Required] public string? Description { get; set; }
    public string? CompletionNote { get; set; }
    public DateTime? ScheduledStartTime { get; set; }
    public DateTime? ScheduledEndTime { get; set; }
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }
    public bool AutomaticStartEnabled { get; set; }
    public bool AutomaticEndEnabled { get; set; }
    public string? Status { get; set; }
    public bool? IsSuccess { get; set; }
}

public class MaintenanceRequestConfiguration : IEntityTypeConfiguration<MaintenanceRequest>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequest> builder)
    {

    }
}