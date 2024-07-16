using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

[PrimaryKey(nameof(ServiceId), nameof(EnvironmentId))]
public class ServiceEnvironmentDetail : BaseModel
{
    [Required]
    public Guid? ServiceId { get; set; }
    [Required]
    public Guid? EnvironmentId { get; set; }
    public bool AutomaticRestartEligible { get; set; }
    [Required]
    public Guid? MinimumHealthStatusTypeIdForAction { get; set; }
    public int ConsecutiveFailuresBeforeAlert { get; set; } = 10;
    public int ConsecutiveFailuresBeforeRestart { get; set; } = 20;
}

public class ServiceEnvironmentDetailConfiguration : IEntityTypeConfiguration<ServiceEnvironmentDetail>
{
    public void Configure(EntityTypeBuilder<ServiceEnvironmentDetail> builder)
    {

    }
}