using System.ComponentModel.DataAnnotations;

namespace CliniqueBackend.Dtos;

public class DoctorDTO
{

    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; } = default!;

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [MaxLength(50)]
    [Required]
    public string LastName { get; set; } = default!;

    [Required]
    public int DepartmentId { get; set; }

    public ICollection<ScheduleDTO> Schedules { get; set; } = new List<ScheduleDTO>();
}