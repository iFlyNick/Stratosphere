using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stratosphere.Data.Models;

public abstract partial class BaseModel
{
    [Required]
    public string? CreatedBy { get; set; }
    [Required]
    public DateTime? CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    [Required]
    public bool IsActive { get; set; } = true;
}
