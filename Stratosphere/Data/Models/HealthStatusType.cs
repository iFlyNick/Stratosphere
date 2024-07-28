using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class HealthStatusType
{
    [Required] public Guid? HealthStatusTypeId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [Required] public string? Name { get; set; }
    [Required] public string? Description { get; set; }
}

public class HealthStatusTypeConfiguration : IEntityTypeConfiguration<HealthStatusType>
{
    public void Configure(EntityTypeBuilder<HealthStatusType> builder)
    {

    }
}