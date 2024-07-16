using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(MaintenanceRequestId), nameof(MaintenanceRequestDetailId), nameof(MaintenanceRequestDetailHistoryId))]
public class MaintenanceRequestDetailHistory : BaseModel
{
    [Required]
    public Guid? MaintenanceRequestId { get; set; }
    [Required]
    public int MaintenanceRequestDetailId { get; set; }
    [Required]
    public int MaintenanceRequestDetailHistoryId { get; set; }
    [Required]
    public Guid? ServiceId { get; set; }
    [Required]
    public Guid? EnvironmentId { get; set; }
    [Required]
    public Guid? AssetId { get; set; }
    [Required]
    public DateTime? ExecutionTime { get; set; }
    [Required]
    public string? Action { get; set; }
    public bool IsSuccess { get; set; }
    public string? StatusMessage { get; set; }
}

public class MaintenanceRequestDetailHistoryConfiguration : IEntityTypeConfiguration<MaintenanceRequestDetailHistory>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequestDetailHistory> builder)
    {

    }
}