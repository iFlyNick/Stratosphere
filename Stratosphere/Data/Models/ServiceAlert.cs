using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(ServiceId), nameof(AlertProfileId), nameof(EnvironmentId))]
public class ServiceAlert
{
    [Required] public Guid? ServiceId { get; set; }
    [Required] public Guid? AlertProfileId { get; set; }
    [Required] public Guid? EnvironmentId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}

public class ServiceAlertConfiguration : IEntityTypeConfiguration<ServiceAlert>
{
    public void Configure(EntityTypeBuilder<ServiceAlert> builder)
    {

    }
}