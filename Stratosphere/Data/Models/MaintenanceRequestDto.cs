using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class MaintenanceRequestDto
{
    //should these include a group concept for searching?
    public Guid? MaintenanceRequestId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Description { get; set; }
    public string? CompletionNote { get; set; }
    public DateTime? ScheduledStartTime { get; set; }
    public DateTime? ScheduledEndTime { get; set; }
    public DateTime? ActualStartTime { get; set; }
    public DateTime? ActualEndTime { get; set; }
    public bool AutomaticStartEnabled { get; set; }
    public bool AutomaticEndEnabled { get; set; }
    public string? Status { get; set; }
    public bool? IsSuccess { get; set; }

    public List<MaintenanceRequestDetailDto>? MaintenanceRequestDetails { get; set; }
}

public class MaintenanceRequestConfiguration : IEntityTypeConfiguration<MaintenanceRequestDto>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequestDto> builder)
    {
        //pk
        builder.HasKey(s => s.MaintenanceRequestId);

        //index


        //required
        builder.Property(s => s.MaintenanceRequestId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);
        builder.Property(s => s.AutomaticStartEnabled).IsRequired();
        builder.Property(s => s.AutomaticEndEnabled).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);
        builder.Property(s => s.CompletionNote).HasMaxLength(1000);
        builder.Property(s => s.Status).HasMaxLength(100);

        //relationships
        builder.HasMany(s => s.MaintenanceRequestDetails).WithOne(s => s.MaintenanceRequest);
    }
}