using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class QueueProviderDetailDto
{
    public Guid? QueueProviderDetailId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid? QueueProviderId { get; set; }

    public QueueProviderDto? QueueProvider { get; set; }
    public List<VirtualHostDto>? VirtualHosts { get; set; }
}

public class QueueProviderDetailDtoConfiguration : IEntityTypeConfiguration<QueueProviderDetailDto>
{
    public void Configure(EntityTypeBuilder<QueueProviderDetailDto> builder)
    {
        //pk
        builder.HasKey(s => s.QueueProviderDetailId);

        //index


        //required
        builder.Property(s => s.QueueProviderDetailId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.QueueProviderId).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.QueueProvider).WithMany(s => s.QueueProviderDetails);
        builder.HasMany(s => s.VirtualHosts).WithOne(s => s.QueueProviderDetail);
    }
}