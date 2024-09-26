using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class AssetDto
{
    public Guid? AssetId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid? AssetTypeId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ConnectionString { get; set; }
    public Guid? ConnectionProfileId { get; set; }


    public AssetTypeDto? AssetType { get; set; }
    public ConnectionProfileDto? ConnectionProfile { get; set; }
    public List<MaintenanceRequestDetailDto>? MaintenanceRequestDetails { get; set; }
    public List<ServiceAssetDto>? ServiceAssets { get; set; }
    public List<ServiceHealthReportDto>? ServiceHealthReports { get; set; }
}

public class AssetConfiguration : IEntityTypeConfiguration<AssetDto>
{
    public void Configure(EntityTypeBuilder<AssetDto> builder)
    {
        //pk
        builder.HasKey(s => s.AssetId);

        //index
        

        //required
        builder.Property(s => s.AssetId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.AssetTypeId).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.ConnectionString).IsRequired().HasMaxLength(255);
        builder.Property(s => s.ConnectionProfileId).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);
        builder.Property(s => s.Description).HasMaxLength(1000);

        //relationships
        builder.HasOne(s => s.AssetType).WithMany(s => s.Assets);
        builder.HasOne(s => s.ConnectionProfile).WithMany(s => s.Assets);
        builder.HasMany(s => s.MaintenanceRequestDetails).WithOne(s => s.Asset);
        builder.HasMany(s => s.ServiceAssets).WithOne(s => s.Asset);
        builder.HasMany(s => s.ServiceHealthReports).WithOne(s => s.Asset);
    }
}