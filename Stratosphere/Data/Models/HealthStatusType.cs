using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class HealthStatusType : BaseModel
{
    [Required]
    public Guid? HealthStatusTypeId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
}

public class HealthStatusTypeConfiguration : IEntityTypeConfiguration<HealthStatusType>
{
    public void Configure(EntityTypeBuilder<HealthStatusType> builder)
    {

    }
}