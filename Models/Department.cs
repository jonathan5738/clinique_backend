using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliniqueBackend.Models;

[Table("departments")]
public class Department
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "varchar(100)")]
    [Required]
    public string Name { get; set; } = default!;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }

    public ICollection<Doctor> Doctors { get; set; } = default!;

}