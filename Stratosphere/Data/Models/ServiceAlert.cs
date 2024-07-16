using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(ServiceId), nameof(AlertProfileId), nameof(EnvironmentId))]
public class ServiceAlert : BaseModel
{
    [Required]
    public Guid? ServiceId { get; set; }
    [Required]
    public Guid? AlertProfileId { get; set; }
    [Required]
    public Guid? EnvironmentId { get; set; }
}

public class ServiceAlertConfiguration : IEntityTypeConfiguration<ServiceAlert>
{
    public void Configure(EntityTypeBuilder<ServiceAlert> builder)
    {

    }
}