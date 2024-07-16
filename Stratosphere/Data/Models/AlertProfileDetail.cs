using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(AlertProfileId), nameof(ContactId))]
public class AlertProfileDetail : BaseModel
{
    [Required]
    public Guid? AlertProfileId { get; set; }
    [Required]
    public Guid? ContactId { get; set; }
}

public class AlertProfileDetailConfiguration : IEntityTypeConfiguration<AlertProfileDetail>
{
    public void Configure(EntityTypeBuilder<AlertProfileDetail> builder)
    {

    }
}