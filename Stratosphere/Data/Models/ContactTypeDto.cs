using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class ContactTypeDto
{
    public Guid? ContactTypeId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public List<ContactDto>? Contacts { get; set; }
}

public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactTypeDto>
{
    public void Configure(EntityTypeBuilder<ContactTypeDto> builder)
    {
        //pk
        builder.HasKey(s => s.ContactTypeId);

        //index


        //required
        builder.Property(s => s.ContactTypeId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
        builder.Property(s => s.Description).IsRequired().HasMaxLength(1000);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasMany(s => s.Contacts).WithOne(s => s.ContactType);
    }
}