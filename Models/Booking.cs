using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliniqueBackend.Models;

[Table("bookings")]
public class Booking
{
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; } = default!;

    [Required]
    [Column(TypeName = "varchar(50)")]
    public string LastName { get; set; } = default!;

    [Column(TypeName = "varchar(50)")]
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

    public int DepartmentId { get; set; }
    public Department Department { get; set; } = default!;

    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; } = default!;


    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}