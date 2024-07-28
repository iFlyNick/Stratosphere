using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(QueueId), nameof(QueueSnapshotId))]
public class QueueSnapshot
{
    [Required] public Guid? QueueId { get; set; }
    [Required] public int QueueSnapshotId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [Required] public Guid? VirtualHostId { get; set; }
    [Required] public Guid? EnvironmentId { get; set; }
    [Required] public int MessageCount { get; set; }
}

public class QueueSnapshotConfiguration : IEntityTypeConfiguration<QueueSnapshot>
{
    public void Configure(EntityTypeBuilder<QueueSnapshot> builder)
    {

    }
}