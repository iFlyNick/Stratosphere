using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class MaintenanceRequestDetailHistoryDto
{
    public Guid? MaintenanceRequestDetailHistoryId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid? MaintenanceRequestDetailId { get; set; }
    public DateTime? ExecutionTime { get; set; }
    public string? Action { get; set; }
    public bool IsSuccess { get; set; }
    public string? StatusMessage { get; set; }

    public MaintenanceRequestDetailDto? MaintenanceRequestDetail { get; set; }
}

public class MaintenanceRequestDetailHistoryConfiguration : IEntityTypeConfiguration<MaintenanceRequestDetailHistoryDto>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequestDetailHistoryDto> builder)
    {
        //pk
        builder.HasKey(s => s.MaintenanceRequestDetailHistoryId);

        //index


        //required
        builder.Property(s => s.MaintenanceRequestDetailHistoryId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.MaintenanceRequestDetailId).IsRequired();
        builder.Property(s => s.ExecutionTime).IsRequired();
        builder.Property(s => s.Action).IsRequired().HasMaxLength(50);
        builder.Property(s => s.IsSuccess).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);
        builder.Property(s => s.StatusMessage).HasMaxLength(1000);

        //relationships
        builder.HasOne(s => s.MaintenanceRequestDetail).WithMany(s => s.MaintenanceRequestDetailHistories);
    }
}