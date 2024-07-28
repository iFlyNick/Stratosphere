using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(ServiceHealthReportId), nameof(ServiceHealthReportDetailId))]
public class ServiceHealthReportDetail
{
    [Required] public Guid? ServiceHealthReportId { get; set; }
    [Required] public int ServiceHealthReportDetailId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [Required] public string? Message { get; set; }
}

public class ServiceHealthReportDetailConfiguration : IEntityTypeConfiguration<ServiceHealthReportDetail>
{
    public void Configure(EntityTypeBuilder<ServiceHealthReportDetail> builder)
    {

    }
}