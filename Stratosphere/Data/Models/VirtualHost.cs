using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;


public class VirtualHost : BaseModel
{
    [Required]
    public Guid? VirtualHostId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public Guid? EnvironmentId { get; set; }
}

public class VirtualHostConfiguration : IEntityTypeConfiguration<VirtualHost>
{
    public void Configure(EntityTypeBuilder<VirtualHost> builder)
    {

    }
}