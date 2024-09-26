using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class QueueSnapshotDto
{
    public Guid? QueueSnapshotId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid? QueueId { get; set; }
    public int MessageCount { get; set; }
    public int UnacknowledgedMessageCount { get; set; }
    public int ReadyMessageCount { get; set; }

    public QueueDto? Queue { get; set; }
}

public class QueueSnapshotConfiguration : IEntityTypeConfiguration<QueueSnapshotDto>
{
    public void Configure(EntityTypeBuilder<QueueSnapshotDto> builder)
    {
        //pk
        builder.HasKey(s => s.QueueSnapshotId);

        //index
        builder.HasIndex(s => s.QueueId);

        //required
        builder.Property(s => s.QueueSnapshotId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.QueueId).IsRequired();
        builder.Property(s => s.MessageCount).IsRequired();
        builder.Property(s => s.UnacknowledgedMessageCount).IsRequired();
        builder.Property(s => s.ReadyMessageCount).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.Queue).WithMany(s => s.QueueSnapshots);
    }
}