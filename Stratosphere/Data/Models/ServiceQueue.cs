using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(ServiceId), nameof(QueueId), nameof(EnvironmentId))]
public class ServiceQueue : BaseModel
{
    [Required]
    public Guid? ServiceId { get; set; }
    [Required]
    public Guid? QueueId { get; set; }
    [Required]
    public Guid? EnvironmentId { get; set; }
}

public class ServiceQueueConfiguration : IEntityTypeConfiguration<ServiceQueue>
{
    public void Configure(EntityTypeBuilder<ServiceQueue> builder)
    {

    }
}