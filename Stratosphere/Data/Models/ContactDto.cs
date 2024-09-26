using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class ContactDto
{
    public Guid? ContactId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }
    public Guid? ContactTypeId { get; set; }
    public string? Value { get; set; }

    public ContactTypeDto? ContactType { get; set; }
    public List<AlertProfileDetailDto>? AlertProfileDetails { get; set; }
}

public class ContactConfiguration : IEntityTypeConfiguration<ContactDto>
{
    public void Configure(EntityTypeBuilder<ContactDto> builder)
    {
        //pk
        builder.HasKey(s => s.ContactId);

        //index


        //required
        builder.Property(s => s.ContactId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.ContactTypeId).IsRequired();
        builder.Property(s => s.Value).IsRequired().HasMaxLength(100);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.ContactType).WithMany(s => s.Contacts);
        builder.HasMany(s => s.AlertProfileDetails).WithOne(s => s.Contact);
    }
}