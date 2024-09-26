using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class ServiceEnvironmentQueueDto
{
    public Guid? ServiceEnvironmentQueueId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid? ServiceId { get; set; }
    public Guid? EnvironmentId { get; set; }
    public Guid? QueueId { get; set; }
    public bool IsConsumer { get; set; }

    public ServiceDto? Service { get; set; }
    public EnvironmentDto? Environment { get; set; }
    public QueueDto? Queue { get; set; }
}

public class ServiceQueueConfiguration : IEntityTypeConfiguration<ServiceEnvironmentQueueDto>
{
    public void Configure(EntityTypeBuilder<ServiceEnvironmentQueueDto> builder)
    {
        //pk
        builder.HasKey(s => new { s.ServiceId, s.QueueId });

        //index


        //required
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.ServiceId).IsRequired();
        builder.Property(s => s.EnvironmentId).IsRequired();
        builder.Property(s => s.QueueId).IsRequired();
        builder.Property(s => s.IsConsumer).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.Service).WithMany(s => s.ServiceQueues);
        builder.HasOne(s => s.Environment).WithMany(s => s.ServiceEnvironmentQueues);
        builder.HasOne(s => s.Queue).WithMany(s => s.ServiceQueues);
    }
}