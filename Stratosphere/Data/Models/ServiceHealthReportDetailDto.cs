using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class ServiceHealthReportDetailDto
{
    public Guid? ServiceHealthReportId { get; set; }
    public int ServiceHealthReportDetailId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Message { get; set; }

    public ServiceHealthReportDto? ServiceHealthReport { get; set; }
}

public class ServiceHealthReportDetailConfiguration : IEntityTypeConfiguration<ServiceHealthReportDetailDto>
{
    public void Configure(EntityTypeBuilder<ServiceHealthReportDetailDto> builder)
    {
        //pk
        builder.HasKey(s => new { s.ServiceHealthReportId, s.ServiceHealthReportDetailId });

        //index


        //required
        builder.Property(s => s.ServiceHealthReportId).IsRequired();
        builder.Property(s => s.ServiceHealthReportDetailId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Message).IsRequired().HasMaxLength(1000);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.ServiceHealthReport).WithMany(s => s.ServiceHealthReportDetails);
    }
}