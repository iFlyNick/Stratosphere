using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class AlarmDto
{
    public Guid? AlarmId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? ExternalReferenceId { get; set; }
}

public class AlarmConfiguration : IEntityTypeConfiguration<AlarmDto>
{
    public void Configure(EntityTypeBuilder<AlarmDto> builder)
    {
        //pk
        builder.HasKey(s => s.AlarmId);

        //index


        //required
        builder.Property(s => s.AlarmId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.ExternalReferenceId).IsRequired().HasMaxLength(50);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships

    }
}
