using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;


public class VirtualHostDto
{
    public Guid? VirtualHostId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }

    public QueueProviderDetailDto? QueueProviderDetail { get; set; }
    public List<QueueDto>? Queues { get; set; }
}

public class VirtualHostConfiguration : IEntityTypeConfiguration<VirtualHostDto>
{
    public void Configure(EntityTypeBuilder<VirtualHostDto> builder)
    {
        //pk
        builder.HasKey(s => s.VirtualHostId);

        //index


        //required
        builder.Property(s => s.VirtualHostId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.QueueProviderDetail).WithMany(s => s.VirtualHosts);
        builder.HasMany(s => s.Queues).WithOne(s => s.VirtualHost);
    }
}