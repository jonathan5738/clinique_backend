using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliniqueBackend.Models;

[Table("schedules")]
public class Schedule
{
    public int Id { get; set; }

    [Required]
    public TimeOnly StartHour { get; set; } = default!;
    
    [Required]
    public TimeOnly EndHour { get; set; } = default!;

    public string Day { get; set; } = default!;
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = default!;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}