using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(AlertProfileId), nameof(ContactId))]
public class AlertProfileDetail
{
    [Required] public Guid? AlertProfileId { get; set; }
    [Required] public Guid? ContactId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

public class AlertProfileDetailConfiguration : IEntityTypeConfiguration<AlertProfileDetail>
{
    public void Configure(EntityTypeBuilder<AlertProfileDetail> builder)
    {

    }
}