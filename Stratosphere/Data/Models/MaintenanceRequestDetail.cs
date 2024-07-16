using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(MaintenanceRequestId), nameof(MaintenanceRequestDetailId))]
public class MaintenanceRequestDetail : BaseModel
{
    [Required]
    public Guid? MaintenanceRequestId { get; set; }
    [Required]
    public int MaintenanceRequestDetailId { get; set; }
    [Required]
    public Guid? ServiceId { get; set; }
    [Required]
    public Guid? EnvironmentId { get; set; }
    [Required]
    public Guid? AssetId { get; set; }
    [Required]
    public int StartOrder { get; set; }
    [Required]
    public int StopOrder { get; set; }
    public bool WaitForQueueClearOnStart { get; set; }
    public bool WaitForQueueClearOnStop { get; set; }
    public bool? IsSuccess { get; set; }
    public string? StatusMessage { get; set; }
}

public class MaintenanceRequestDetailConfiguration : IEntityTypeConfiguration<MaintenanceRequestDetail>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequestDetail> builder)
    {

    }
}