using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class ServiceDto
{
    public Guid? ServiceId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? ServiceTypeId { get; set; }

    public ServiceTypeDto? ServiceType { get; set; }
    public List<MaintenanceRequestDetailDto>? MaintenanceRequestDetails { get; set; }
    public List<MaintenanceTemplateDetailDto>? MaintenanceTemplateDetails { get; set; }
    public List<ServiceAlertDto>? ServiceAlerts { get; set; }
    public List<ServiceAssetDto>? ServiceAssets { get; set; }
    public List<ServiceEnvironmentDetailDto>? ServiceEnvironmentDetails { get; set; }
    public List<ServiceHealthReportDto>? ServiceHealthReports { get; set; }
    public List<ServiceEnvironmentQueueDto>? ServiceQueues { get; set; }
}

public class ServiceConfiguration : IEntityTypeConfiguration<ServiceDto>
{
    public void Configure(EntityTypeBuilder<ServiceDto> builder)
    {
        //pk
        builder.HasKey(s => s.ServiceId);

        //index


        //required
        builder.Property(s => s.ServiceId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);
        builder.Property(s => s.ServiceTypeId).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.ServiceType).WithMany(s => s.Services);
        builder.HasMany(s => s.MaintenanceRequestDetails).WithOne(s => s.Service);
        builder.HasMany(s => s.MaintenanceTemplateDetails).WithOne(s => s.Service);
        builder.HasMany(s => s.ServiceAlerts).WithOne(s => s.Service);
        builder.HasMany(s => s.ServiceAssets).WithOne(s => s.Service);
        builder.HasMany(s => s.ServiceEnvironmentDetails).WithOne(s => s.Service);
        builder.HasMany(s => s.ServiceHealthReports).WithOne(s => s.Service);
        builder.HasMany(s => s.ServiceQueues).WithOne(s => s.Service);
    }
}