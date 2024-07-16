using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class Contact : BaseModel
{
    [Required]
    public Guid? ContactId { get; set; }
    [Required] 
    public string? Name { get; set; }
    [Required]
    public Guid? ContactTypeId { get; set; }
    [Required]
    public string? Value { get; set; }
}

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {

    }
}