using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliniqueBackend.Models;

[Table("events")]
public class Event
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = default!;

    [Required]
    public string Description { get; set; } = default!;
    
    [Required]
    public string PersonInCharge { get; set; } = default!;

    public int DepartmentId { get; set; }
    public Department Department { get; set; } = default!;
    public ICollection<EventSchedule> Schedules { get; set; } = new List<EventSchedule>();

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}