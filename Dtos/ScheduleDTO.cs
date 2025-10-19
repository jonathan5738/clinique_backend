using System.ComponentModel.DataAnnotations;
using CliniqueBackend.Models;

namespace CliniqueBackend.Dtos;

public class ScheduleDTO
{
    public int ScheduleId { get; set; }
    [Required]
    public TimeOnly StartHour { get; set; } = default!;
    
    [Required]
    public TimeOnly EndHour { get; set; } = default!;

    public string Day { get; set; } = default!;
    public int? DoctorId { get; set; }
}