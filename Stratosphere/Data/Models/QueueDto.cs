using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class QueueDto
{
    public Guid? QueueId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }
    public Guid? VirtualHostId { get; set; }

    public VirtualHostDto? VirtualHost { get; set; }
    public List<QueueSnapshotDto>? QueueSnapshots { get; set; }
    public List<ServiceEnvironmentQueueDto>? ServiceQueues { get; set; }
}

public class QueueConfiguration : IEntityTypeConfiguration<QueueDto>
{
    public void Configure(EntityTypeBuilder<QueueDto> builder)
    {
        //pk
        builder.HasKey(s => s.QueueId);

        //index


        //required
        builder.Property(s => s.QueueId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.VirtualHostId).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.VirtualHost).WithMany(s => s.Queues);
        builder.HasMany(s => s.QueueSnapshots).WithOne(s => s.Queue);
        builder.HasMany(s => s.ServiceQueues).WithOne(s => s.Queue);
    }
}