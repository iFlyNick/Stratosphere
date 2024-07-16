using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class AlertHistory : BaseModel
{
    [Required]
    public Guid? AlertHistoryId { get; set; }
    [Required]
    public Guid? AlertProfileId { get; set; }
    [Required]
    public DateTime? AlertTime { get; set; }
    [Required]
    public Guid? ServiceHealthReportId { get; set; }
    [Required]
    public string? AlertMessage { get; set; }
}

public class AlertHistoryConfiguration : IEntityTypeConfiguration<AlertHistory>
{
    public void Configure(EntityTypeBuilder<AlertHistory> builder)
    {

    }
}