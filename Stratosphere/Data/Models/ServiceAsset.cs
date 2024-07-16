using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(ServiceId), nameof(AssetId), nameof(EnvironmentId))]
public class ServiceAsset : BaseModel
{
    [Required]
    public Guid? ServiceId { get; set; }
    [Required]
    public Guid? AssetId { get; set; }
    [Required]
    public Guid? EnvironmentId { get; set; }
    public string? OverrideName { get; set; }
}

public class ServiceAssetConfiguration : IEntityTypeConfiguration<ServiceAsset>
{
    public void Configure(EntityTypeBuilder<ServiceAsset> builder)
    {

    }
}