using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class ServiceType : BaseModel
{
    [Required]
    public Guid? ServiceTypeId { get; set; }
    [Required]
    public string? Name { get; set; }
}

public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
{
    public void Configure(EntityTypeBuilder<ServiceType> builder)
    {

    }
}