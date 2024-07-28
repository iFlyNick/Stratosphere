using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class Environment
{
    [Required] public Guid? EnvironmentId { get; set; }
    [Required] public string? CreatedBy { get; set; }
    [Required] public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [Required] public string? Name { get; set; }
    [Required] public string? Description { get; set; }
}

public class EnvironmentConfiguration : IEntityTypeConfiguration<Environment>
{
    public void Configure(EntityTypeBuilder<Environment> builder)
    {

    }
}