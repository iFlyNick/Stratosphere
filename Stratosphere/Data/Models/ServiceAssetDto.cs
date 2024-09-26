using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class ServiceAssetDto
{
    public Guid? ServiceId { get; set; }
    public Guid? AssetId { get; set; }
    public Guid? EnvironmentId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? OverrideName { get; set; } //maybe a docker container name??

    public ServiceDto? Service { get; set; }
    public AssetDto? Asset { get; set; }
    public EnvironmentDto? Environment { get; set; }
}

public class ServiceAssetConfiguration : IEntityTypeConfiguration<ServiceAssetDto>
{
    public void Configure(EntityTypeBuilder<ServiceAssetDto> builder)
    {
        //pk
        builder.HasKey(s => new { s.ServiceId, s.AssetId, s.EnvironmentId });

        //index


        //required
        builder.Property(s => s.ServiceId).IsRequired();
        builder.Property(s => s.AssetId).IsRequired();
        builder.Property(s => s.EnvironmentId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);
        builder.Property(s => s.OverrideName).HasMaxLength(100);

        //relationships
        builder.HasOne(s => s.Service).WithMany(s => s.ServiceAssets);
        builder.HasOne(s => s.Asset).WithMany(s => s.ServiceAssets);
        builder.HasOne(s => s.Environment).WithMany(s => s.ServiceAssets);
    }
}