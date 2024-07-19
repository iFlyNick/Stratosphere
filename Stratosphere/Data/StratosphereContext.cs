using Microsoft.EntityFrameworkCore;
using Stratosphere.Data.Models;

namespace Stratosphere.Data;

public class StratosphereContext(DbContextOptions<StratosphereContext> options) : DbContext(options)
{
    public DbSet<Alarm> Alarm { get; set; }
    public DbSet<AlertHistory> AlertHistory { get; set; }
    public DbSet<AlertProfile> AlertProfile { get; set; }
    public DbSet<AlertProfileDetail> AlertProfileDetail { get; set; }
    public DbSet<Asset> Asset { get; set; }
    public DbSet<AssetType> AssetType { get; set; }
    public DbSet<Contact> Contact { get; set; }
    public DbSet<ContactType> ContactType { get; set; }
    public DbSet<Models.Environment> Environment { get; set; }
    public DbSet<HealthStatusType> HealthStatusType { get; set; }
    public DbSet<MaintenanceRequest> MaintenanceRequest { get; set; }
    public DbSet<MaintenanceRequestDetail> MaintenanceRequestDetail { get; set; }
    public DbSet<MaintenanceRequestDetailHistory> MaintenanceRequestDetailHistory { get; set; }
    public DbSet<MaintenanceTemplate> MaintenanceTemplate { get; set; }
    public DbSet<MaintenanceTemplateDetail> MaintenanceTemplateDetail { get; set; }
    public DbSet<Queue> Queue { get; set; }
    public DbSet<QueueSnapshot> QueueSnapshot { get; set; }
    public DbSet<Service> Service { get; set; }
    public DbSet<ServiceAlert> ServiceAlert { get; set; }
    public DbSet<ServiceAsset> ServiceAsset { get; set; }
    public DbSet<ServiceEnvironmentDetail> ServiceEnvironmentDetail { get; set; }
    public DbSet<ServiceHealthReport> ServiceHealthReport { get; set; }
    public DbSet<ServiceHealthReportDetail> ServiceHealthReportDetail { get; set; }
    public DbSet<ServiceQueue> ServiceQueue { get; set; }
    public DbSet<ServiceType> ServiceType { get; set; }
    public DbSet<VirtualHost> VirtualHost { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    //optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;User Id=postgres;Password=postgres;Database=stratosphere")
    //.UseSnakeCaseNamingConvention();

    //abstracts the fluentapi calls to the configuration classes to keep this class relatively clean
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
}
