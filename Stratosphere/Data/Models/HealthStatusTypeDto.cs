using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class HealthStatusTypeDto
{
    public Guid? HealthStatusTypeId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public List<ServiceEnvironmentDetailDto>? ServiceEnvironmentDetails { get; set; }
    public List<ServiceHealthReportDto>? ServiceHealthReports { get; set; }
}

public class HealthStatusTypeConfiguration : IEntityTypeConfiguration<HealthStatusTypeDto>
{
    public void Configure(EntityTypeBuilder<HealthStatusTypeDto> builder)
    {
        //pk
        builder.HasKey(s => s.HealthStatusTypeId);

        //index


        //required
        builder.Property(s => s.HealthStatusTypeId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasMany(s => s.ServiceEnvironmentDetails).WithOne(s => s.HealthStatusType);
        builder.HasMany(s => s.ServiceHealthReports).WithOne(s => s.HealthStatusType);
    }
}