using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class Queue : BaseModel
{
    [Required]
    public Guid? QueueId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public Guid? VirtualHostId { get; set; }
    [Required]
    public Guid? EnvironmentId { get; set; }
}

public class QueueConfiguration : IEntityTypeConfiguration<Queue>
{
    public void Configure(EntityTypeBuilder<Queue> builder)
    {

    }
}