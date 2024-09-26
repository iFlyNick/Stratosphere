using Microsoft.EntityFrameworkCore;
using Stratosphere.Data.Models;

namespace Stratosphere.Data;

public class StratosphereContext(DbContextOptions<StratosphereContext> options) : DbContext(options)
{
    public DbSet<AlarmDto> Alarm { get; set; }
    public DbSet<AlertHistoryDto> AlertHistory { get; set; }
    public DbSet<AlertProfileDto> AlertProfile { get; set; }
    public DbSet<AlertProfileDetailDto> AlertProfileDetail { get; set; }
    public DbSet<AssetDto> Asset { get; set; }
    public DbSet<AssetTypeDto> AssetType { get; set; }
    public DbSet<ConnectionProfileDto> ConnectionProfile { get; set; }
    public DbSet<ContactDto> Contact { get; set; }
    public DbSet<ContactTypeDto> ContactType { get; set; }
    public DbSet<Models.EnvironmentDto> Environment { get; set; }
    public DbSet<HealthStatusTypeDto> HealthStatusType { get; set; }
    public DbSet<MaintenanceRequestDto> MaintenanceRequest { get; set; }
    public DbSet<MaintenanceRequestDetailDto> MaintenanceRequestDetail { get; set; }
    public DbSet<MaintenanceRequestDetailHistoryDto> MaintenanceRequestDetailHistory { get; set; }
    public DbSet<MaintenanceTemplateDto> MaintenanceTemplate { get; set; }
    public DbSet<MaintenanceTemplateDetailDto> MaintenanceTemplateDetail { get; set; }
    public DbSet<QueueDto> Queue { get; set; }
    public DbSet<QueueSnapshotDto> QueueSnapshot { get; set; }
    public DbSet<ServiceDto> Service { get; set; }
    public DbSet<ServiceAlertDto> ServiceAlert { get; set; }
    public DbSet<ServiceAssetDto> ServiceAsset { get; set; }
    public DbSet<ServiceEnvironmentDetailDto> ServiceEnvironmentDetail { get; set; }
    public DbSet<ServiceHealthReportDto> ServiceHealthReport { get; set; }
    public DbSet<ServiceHealthReportDetailDto> ServiceHealthReportDetail { get; set; }
    public DbSet<ServiceEnvironmentQueueDto> ServiceQueue { get; set; }
    public DbSet<ServiceTypeDto> ServiceType { get; set; }
    public DbSet<VirtualHostDto> VirtualHost { get; set; }

    //abstracts the fluentapi calls to the configuration classes to keep this class relatively clean
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}
