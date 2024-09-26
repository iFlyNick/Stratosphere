using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class AssetTypeDto
{
    public Guid? AssetTypeId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public List<AssetDto>? Assets { get; set; }
}

public class AssetTypeConfiguration : IEntityTypeConfiguration<AssetTypeDto>
{
    public void Configure(EntityTypeBuilder<AssetTypeDto> builder)
    {
        //pk
        builder.HasKey(s => s.AssetTypeId);

        //index


        //required
        builder.Property(s => s.AssetTypeId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasMany(s => s.Assets).WithOne(s => s.AssetType);
    }
}