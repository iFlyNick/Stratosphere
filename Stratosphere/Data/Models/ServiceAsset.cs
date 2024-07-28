using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(ServiceId), nameof(AssetId), nameof(EnvironmentId))]
public class ServiceAsset
{
    [Required] public Guid? ServiceId { get; set; }
    [Required] public Guid? AssetId { get; set; }
    [Required] public Guid? EnvironmentId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? OverrideName { get; set; }
}

public class ServiceAssetConfiguration : IEntityTypeConfiguration<ServiceAsset>
{
    public void Configure(EntityTypeBuilder<ServiceAsset> builder)
    {

    }
}