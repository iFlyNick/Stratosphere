using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Stratosphere.Data.Models;

public class ServiceTypeDto
{
    public Guid? ServiceTypeId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? Name { get; set; }

    public List<ServiceDto>? Services { get; set; }
}

public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceTypeDto>
{
    public void Configure(EntityTypeBuilder<ServiceTypeDto> builder)
    {
        //pk
        builder.HasKey(s => s.ServiceTypeId);

        //index


        //required
        builder.Property(s => s.ServiceTypeId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.Name).IsRequired().HasMaxLength(50);

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasMany(s => s.Services).WithOne(s => s.ServiceType);
    }
}