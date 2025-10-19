using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliniqueBackend.Models;

[Table("doctors")]
public class Doctor
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(50)")]
    [Required]
    public string FirstName { get; set; } = default!;

    [Column(TypeName = "varchar(50)")]
    public string? MiddleName { get; set; }

    [Column(TypeName = "varchar(75)")]
    [Required]
    public string LastName { get; set; } = default!;

    public int DepartmentId { get; set; }
    public Department Department { get; set; } = default!;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
    public ICollection<Schedule> Schedules { get; set; } = default!;
}