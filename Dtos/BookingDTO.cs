using System.ComponentModel.DataAnnotations;

namespace CliniqueBackend.Dtos;

public class BookingDTO
{
    
    [Required]
    [MaxLength(50)]
    [MinLength(4)]
    public string FirstName { get; set; } = default!;

    [Required]
    [MaxLength(50)]
    [MinLength(4)]
    public string LastName { get; set; } = default!;

    [MaxLength(50)]
    [MinLength(4)]
    public string? MiddleName { get; set; } = default!;

    [EmailAddress]
    public string? EmailAddress { get; set; }

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = default!;

    [Required]
    public DateOnly SelectedDate { get; set; } = default!;

    [Required]
    public TimeOnly SelectedTime { get; set; } = default!;


    [Required]
    public int DepartmentId { get; set; }
    [Required]
    public int DoctorId { get; set; }
}