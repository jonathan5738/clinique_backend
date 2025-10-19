using System.ComponentModel.DataAnnotations;

namespace CliniqueBackend.Dtos;

public class EventDTO
{
    
    [Required]
    public string Title { get; set; } = default!;

    [Required]
    public string Description { get; set; } = default!;
    
    [Required]
    public string PersonInCharge { get; set; } = default!;

    public int DepartmentId { get; set; }

    public ICollection<EventScheduleDTO> Schedules { get; set; } = new List<EventScheduleDTO>();
}