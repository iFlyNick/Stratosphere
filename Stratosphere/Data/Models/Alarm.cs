using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class Alarm : BaseModel
{
    [Required]
    public Guid? AlarmId { get; set; }
    [Required]
    public string? ReferenceId { get; set; }
}

public class AlarmConfiguration : IEntityTypeConfiguration<Alarm>
{
    public void Configure(EntityTypeBuilder<Alarm> builder)
    {

    }
}
