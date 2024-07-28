using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class ServiceHealthReport
{
    [Required] public Guid? ServiceHealthReportId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [Required] public Guid? ServiceId { get; set; }
    [Required] public Guid? EnvironmentId { get; set; }
    [Required] public Guid? AssetId { get; set; }
    [Required] public Guid? HealthStatusTypeId { get; set; }
}

public class ServiceHealthReportConfiguration : IEntityTypeConfiguration<ServiceHealthReport>
{
    public void Configure(EntityTypeBuilder<ServiceHealthReport> builder)
    {
        builder.HasIndex(i => i.ServiceId);
    }
}