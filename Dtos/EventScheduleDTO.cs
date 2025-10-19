using System.ComponentModel.DataAnnotations;
namespace CliniqueBackend.Dtos;

public class EventScheduleDTO
{
    public int ScheduleId { get; set; } 
    [Required]
    public DateOnly Date { get; set; } = default!;

    [Required]
    public TimeOnly StartHour { get; set; } = default!;

    [Required]
    public TimeOnly EndHour { get; set; } = default!;
    public int EventId { get; set; }
}