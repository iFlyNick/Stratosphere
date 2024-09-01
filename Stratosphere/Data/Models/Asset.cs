using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class Asset
{
    [Required] public Guid? AssetId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [Required] public Guid? AssetTypeId { get; set; }
    [Required] public string? Name { get; set; }
    public string? Description { get; set; }
    [Required] public string? ConnectionString { get; set; }
    [Required] public Guid? ConnectionProfileId { get; set; }


    [Required] public AssetType? AssetType { get; set; }
    [Required] public ConnectionProfile? ConnectionProfile { get; set; }
}

public class AssetConfiguration : IEntityTypeConfiguration<Asset>
{
    public void Configure(EntityTypeBuilder<Asset> builder)
    {

    }
}