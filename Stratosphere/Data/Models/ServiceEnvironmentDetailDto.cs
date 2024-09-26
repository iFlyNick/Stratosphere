using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class ServiceEnvironmentDetailDto
{
    public Guid? ServiceId { get; set; }
    public Guid? EnvironmentId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public bool AutomaticRestartEligible { get; set; }
    public Guid? MinimumHealthStatusTypeIdForAction { get; set; }
    public int ConsecutiveFailuresBeforeAlert { get; set; } = 10;
    public int ConsecutiveFailuresBeforeRestart { get; set; } = 20;

    public ServiceDto? Service { get; set; }
    public EnvironmentDto? Environment { get; set; }
    public HealthStatusTypeDto? HealthStatusType { get; set; }
}

public class ServiceEnvironmentDetailConfiguration : IEntityTypeConfiguration<ServiceEnvironmentDetailDto>
{
    public void Configure(EntityTypeBuilder<ServiceEnvironmentDetailDto> builder)
    {
        //pk
        builder.HasKey(s => new { s.ServiceId, s.EnvironmentId });

        //index


        //required
        builder.Property(s => s.ServiceId).IsRequired();
        builder.Property(s => s.EnvironmentId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.AutomaticRestartEligible).IsRequired();
        builder.Property(s => s.MinimumHealthStatusTypeIdForAction).IsRequired();
        builder.Property(s => s.ConsecutiveFailuresBeforeAlert).IsRequired();
        builder.Property(s => s.ConsecutiveFailuresBeforeRestart).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.Service).WithMany(s => s.ServiceEnvironmentDetails);
        builder.HasOne(s => s.Environment).WithMany(s => s.ServiceEnvironmentDetails);
        builder.HasOne(s => s.HealthStatusType).WithMany(s => s.ServiceEnvironmentDetails);
    }
}