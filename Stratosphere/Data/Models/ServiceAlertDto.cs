using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class ServiceAlertDto
{
    public Guid? ServiceId { get; set; }
    public Guid? AlertProfileId { get; set; }
    public Guid? EnvironmentId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public ServiceDto? Service { get; set; }
    public AlertProfileDto? AlertProfile { get; set; }
    public EnvironmentDto? Environment { get; set; }
}

public class ServiceAlertConfiguration : IEntityTypeConfiguration<ServiceAlertDto>
{
    public void Configure(EntityTypeBuilder<ServiceAlertDto> builder)
    {
        //pk
        builder.HasKey(s => new { s.ServiceId, s.AlertProfileId, s.EnvironmentId });

        //index


        //required
        builder.Property(s => s.ServiceId).IsRequired();
        builder.Property(s => s.AlertProfileId).IsRequired();
        builder.Property(s => s.EnvironmentId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.Service).WithMany(s => s.ServiceAlerts);
        builder.HasOne(s => s.AlertProfile).WithMany(s => s.ServiceAlerts);
        builder.HasOne(s => s.Environment).WithMany(s => s.ServiceAlerts);
    }
}