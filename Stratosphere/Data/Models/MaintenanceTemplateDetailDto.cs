using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Stratosphere.Data.Models;

public class MaintenanceTemplateDetailDto
{
    public Guid? MaintenanceTemplateId { get; set; }
    public int MaintenanceTemplateDetailId { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid? ServiceId { get; set; }
    public Guid? EnvironmentId { get; set; }
    public int StartOrder { get; set; }
    public int StopOrder { get; set; }
    public bool WaitForQueueClearOnStart { get; set; }
    public bool WaitForQueueClearOnStop { get; set; }

    public MaintenanceTemplateDto? MaintenanceTemplate { get; set; }
    public ServiceDto? Service { get; set; }
    public EnvironmentDto? Environment { get; set; }
}

public class MaintenanceTemplateDetailConfiguration : IEntityTypeConfiguration<MaintenanceTemplateDetailDto>
{
    public void Configure(EntityTypeBuilder<MaintenanceTemplateDetailDto> builder)
    {
        //pk
        builder.HasKey(s => new { s.MaintenanceTemplateId, s.MaintenanceTemplateDetailId });

        //index


        //required
        builder.Property(s => s.MaintenanceTemplateId).IsRequired();
        builder.Property(s => s.MaintenanceTemplateDetailId).IsRequired();
        builder.Property(s => s.CreatedBy).IsRequired().HasMaxLength(50);
        builder.Property(s => s.CreatedDate).IsRequired();
        builder.Property(s => s.ServiceId).IsRequired();
        builder.Property(s => s.EnvironmentId).IsRequired();
        builder.Property(s => s.StartOrder).IsRequired();
        builder.Property(s => s.StopOrder).IsRequired();
        builder.Property(s => s.WaitForQueueClearOnStart).IsRequired();
        builder.Property(s => s.WaitForQueueClearOnStop).IsRequired();

        //other
        builder.Property(s => s.ModifiedBy).HasMaxLength(50);

        //relationships
        builder.HasOne(s => s.MaintenanceTemplate).WithMany(s => s.MaintenanceTemplateDetails);
        builder.HasOne(s => s.Service).WithMany(s => s.MaintenanceTemplateDetails);
        builder.HasOne(s => s.Environment).WithMany(s => s.MaintenanceTemplateDetails);
    }
}