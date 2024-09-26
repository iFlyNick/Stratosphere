using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class AlertHistoryDto
{
    public Guid? AlertHistoryId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid? AlertProfileId { get; set; }
    public Guid? ServiceHealthReportId { get; set; }
    public DateTime? AlertTime { get; set; }
    public string? AlertMessage { get; set; }

    public AlertProfileDto? AlertProfile { get; set; }
    public ServiceHealthReportDto? ServiceHealthReport { get; set; }
}

public class AlertHistoryConfiguration : IEntityTypeConfiguration<AlertHistoryDto>
{
    public void Configure(EntityTypeBuilder<AlertHistoryDto> builder)
    {
        //pk
        builder.HasKey(s => s.AlertHistoryId);

        //index
        builder.HasIndex(s => s.AlertTime);

        //required
        builder.Property(s => s.AlertHistoryId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.AlertProfileId).IsRequired();
        builder.Property(s => s.ServiceHealthReportId).IsRequired();
        builder.Property(s => s.AlertTime).IsRequired();
        builder.Property(s => s.AlertMessage).IsRequired().HasMaxLength(1000);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.AlertProfile).WithMany(s => s.AlertHistories);
        builder.HasOne(s => s.ServiceHealthReport).WithMany(s => s.AlertHistories);
    }
}