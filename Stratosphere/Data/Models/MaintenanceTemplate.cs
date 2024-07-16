using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class MaintenanceTemplate : BaseModel
{
    [Required]
    public Guid? MaintenanceTemplateId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Description { get; set; }
}

public class MaintenanceTemplateConfiguration : IEntityTypeConfiguration<MaintenanceTemplate>
{
    public void Configure(EntityTypeBuilder<MaintenanceTemplate> builder)
    {

    }
}