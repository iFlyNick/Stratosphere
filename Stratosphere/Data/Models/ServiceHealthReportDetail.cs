using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(ServiceHealthReportId), nameof(ServiceHealthReportDetailId))]
public class ServiceHealthReportDetail : BaseModel
{
    [Required]
    public Guid? ServiceHealthReportId { get; set; }
    [Required]
    public int ServiceHealthReportDetailId { get; set; }
    [Required]
    public string? Message { get; set; }
}

public class ServiceHealthReportDetailConfiguration : IEntityTypeConfiguration<ServiceHealthReportDetail>
{
    public void Configure(EntityTypeBuilder<ServiceHealthReportDetail> builder)
    {

    }
}