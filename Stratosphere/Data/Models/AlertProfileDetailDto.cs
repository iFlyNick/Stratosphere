using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class AlertProfileDetailDto
{
    public Guid? AlertProfileId { get; set; }
    public Guid? ContactId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public AlertProfileDto? AlertProfile { get; set; }
    public ContactDto? Contact { get; set; }
}

public class AlertProfileDetailConfiguration : IEntityTypeConfiguration<AlertProfileDetailDto>
{
    public void Configure(EntityTypeBuilder<AlertProfileDetailDto> builder)
    {
        //pk
        builder.HasKey(s => new { s.AlertProfileId, s.ContactId });

        //index


        //required
        builder.Property(s => s.AlertProfileId).IsRequired();
        builder.Property(s => s.ContactId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.AlertProfile).WithMany(s => s.AlertProfileDetails);
        builder.HasOne(s => s.Contact).WithMany(s => s.AlertProfileDetails);
    }
}