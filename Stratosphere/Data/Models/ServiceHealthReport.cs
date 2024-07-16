using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class ServiceHealthReport : BaseModel
{
    [Required]
    public Guid? ServiceHealthReportId { get; set; }
    [Required]
    public Guid? ServiceId { get; set; }
    [Required]
    public Guid? EnvironmentId { get; set; }
    [Required]
    public Guid? AssetId { get; set; }
    [Required]
    public Guid? HealthStatusTypeId { get; set; }
}

public class ServiceHealthReportConfiguration : IEntityTypeConfiguration<ServiceHealthReport>
{
    public void Configure(EntityTypeBuilder<ServiceHealthReport> builder)
    {
        builder.HasIndex(i => i.ServiceId);
    }
}