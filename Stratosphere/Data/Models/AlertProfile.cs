using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class AlertProfile
{
    [Required] public Guid? AlertProfileId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [Required] public string? Name { get; set; }
    [Required] public string? Description { get; set; }
}

public class AlertProfileConfiguration : IEntityTypeConfiguration<AlertProfile>
{
    public void Configure(EntityTypeBuilder<AlertProfile> builder)
    {

    }
}