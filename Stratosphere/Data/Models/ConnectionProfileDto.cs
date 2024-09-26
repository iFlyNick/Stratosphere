using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

//used to setup the connection profile for the assets. this is separate from user accounts and is simply for app to server communication
public class ConnectionProfileDto
{
    public Guid? ConnectionProfileId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }

    public List<AssetDto>? Assets { get; set; }
    public List<QueueProviderDto>? QueueProviders { get; set; }
}

public class ConnectionProfileConfiguration : IEntityTypeConfiguration<ConnectionProfileDto>
{
    public void Configure(EntityTypeBuilder<ConnectionProfileDto> builder)
    {
        //pk
        builder.HasKey(s => s.ConnectionProfileId);

        //index


        //required
        builder.Property(s => s.ConnectionProfileId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.UserName).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Password).IsRequired().HasMaxLength(100);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasMany(s => s.Assets).WithOne(s => s.ConnectionProfile);
        builder.HasMany(s => s.QueueProviders).WithOne(s => s.ConnectionProfile);
    }
}
