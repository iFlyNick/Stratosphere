using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class MaintenanceRequestDetailDto
{
    public Guid? MaintenanceRequestDetailId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid? MaintenanceRequestId { get; set; }
    public Guid? ServiceId { get; set; }
    public Guid? EnvironmentId { get; set; }
    public Guid? AssetId { get; set; }
    public int StartOrder { get; set; }
    public int StopOrder { get; set; }
    public bool WaitForQueueClearOnStart { get; set; }
    public bool WaitForQueueClearOnStop { get; set; }
    public bool? IsSuccess { get; set; }
    public string? StatusMessage { get; set; }

    public MaintenanceRequestDto? MaintenanceRequest { get; set; }
    public ServiceDto? Service { get; set; }
    public EnvironmentDto? Environment { get; set; }
    public AssetDto? Asset { get; set; }
    public List<MaintenanceRequestDetailHistoryDto>? MaintenanceRequestDetailHistories { get; set; }
}

public class MaintenanceRequestDetailConfiguration : IEntityTypeConfiguration<MaintenanceRequestDetailDto>
{
    public void Configure(EntityTypeBuilder<MaintenanceRequestDetailDto> builder)
    {
        //pk
        builder.HasKey(s => s.MaintenanceRequestDetailId);

        //index
        builder.HasIndex(s => s.MaintenanceRequestId);

        //required
        builder.Property(s => s.MaintenanceRequestDetailId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.MaintenanceRequestId).IsRequired();
        builder.Property(s => s.ServiceId).IsRequired();
        builder.Property(s => s.EnvironmentId).IsRequired();
        builder.Property(s => s.AssetId).IsRequired();
        builder.Property(s => s.StartOrder).IsRequired();
        builder.Property(s => s.StopOrder).IsRequired();

        //other
        builder.Property(s => s.StatusMessage).HasMaxLength(1000);

        //relationships
        builder.HasOne(s => s.MaintenanceRequest).WithMany(s => s.MaintenanceRequestDetails);
        builder.HasOne(s => s.Service).WithMany(s => s.MaintenanceRequestDetails);
        builder.HasOne(s => s.Environment).WithMany(s => s.MaintenanceRequestDetails);
        builder.HasOne(s => s.Asset).WithMany(s => s.MaintenanceRequestDetails);
        builder.HasMany(s => s.MaintenanceRequestDetailHistories).WithOne(s => s.MaintenanceRequestDetail);
    }
}