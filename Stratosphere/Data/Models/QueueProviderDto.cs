using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class QueueProviderDto
{
    public Guid? QueueProviderId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? ConnectionProfileId { get; set; }

    public ConnectionProfileDto? ConnectionProfile { get; set; }
    public List<QueueProviderDetailDto>? QueueProviderDetails { get; set; }
}

public class QueueProviderDtoConfiguration : IEntityTypeConfiguration<QueueProviderDto>
{
    public void Configure(EntityTypeBuilder<QueueProviderDto> builder)
    {
        //pk
        builder.HasKey(s => s.QueueProviderId);

        //index


        //required
        builder.Property(s => s.QueueProviderId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);
        builder.Property(s => s.ConnectionProfileId).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.ConnectionProfile).WithMany(s => s.QueueProviders);
        builder.HasMany(s => s.QueueProviderDetails).WithOne(s => s.QueueProvider);
    }
}
