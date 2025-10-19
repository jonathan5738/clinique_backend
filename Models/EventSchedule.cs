using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliniqueBackend.Models;

[Table("event_schedules")]
public class EventSchedule
{
    public int Id { get; set; }

    [Required]
    public DateOnly Date { get; set; } = default!;

    [Required]
    public TimeOnly StartHour { get; set; } = default!;

    [Required]
    public TimeOnly EndHour { get; set; } = default!;
    public int EventId { get; set; }
    public Event Event { get; set; } = default!;

}