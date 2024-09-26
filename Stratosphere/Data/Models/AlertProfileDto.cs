using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class AlertProfileDto
{
    public Guid? AlertProfileId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public List<AlertHistoryDto>? AlertHistories { get; set; }
    public List<AlertProfileDetailDto>? AlertProfileDetails { get; set; }
    public List<ServiceAlertDto>? ServiceAlerts { get; set; }
}

public class AlertProfileConfiguration : IEntityTypeConfiguration<AlertProfileDto>
{
    public void Configure(EntityTypeBuilder<AlertProfileDto> builder)
    {
        //pk
        builder.HasKey(s => s.AlertProfileId);

        //index


        //required
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasMany(s => s.AlertHistories).WithOne(s => s.AlertProfile);
        builder.HasMany(s => s.AlertProfileDetails).WithOne(s => s.AlertProfile);
        builder.HasMany(s => s.ServiceAlerts).WithOne(s => s.AlertProfile);
    }
}