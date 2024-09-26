using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class ServiceHealthReportDto
{
    public Guid? ServiceHealthReportId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid? ServiceId { get; set; }
    public Guid? EnvironmentId { get; set; }
    public Guid? AssetId { get; set; }
    public Guid? HealthStatusTypeId { get; set; }

    public AssetDto? Asset { get; set; }
    public EnvironmentDto? Environment { get; set; }
    public HealthStatusTypeDto? HealthStatusType { get; set; }
    public ServiceDto? Service { get; set; }
    public List<AlertHistoryDto>? AlertHistories { get; set; }
    public List<ServiceHealthReportDetailDto>? ServiceHealthReportDetails { get; set; }
}

public class ServiceHealthReportConfiguration : IEntityTypeConfiguration<ServiceHealthReportDto>
{
    public void Configure(EntityTypeBuilder<ServiceHealthReportDto> builder)
    {
        //pk
        builder.HasKey(s => s.ServiceHealthReportId);

        //index


        //required
        builder.Property(s => s.ServiceHealthReportId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.ServiceId).IsRequired();
        builder.Property(s => s.EnvironmentId).IsRequired();
        builder.Property(s => s.AssetId).IsRequired();
        builder.Property(s => s.HealthStatusTypeId).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.Asset).WithMany(s => s.ServiceHealthReports);
        builder.HasOne(s => s.Environment).WithMany(s => s.ServiceHealthReports);
        builder.HasOne(s => s.HealthStatusType).WithMany(s => s.ServiceHealthReports);
        builder.HasOne(s => s.Service).WithMany(s => s.ServiceHealthReports);
        builder.HasMany(s => s.AlertHistories).WithOne(s => s.ServiceHealthReport);
        builder.HasMany(s => s.ServiceHealthReportDetails).WithOne(s => s.ServiceHealthReport);
    }
}