using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Models;

[Table("fqs")]
[Comment("this is table will contain frequently asked question with their answers")]
public class Fq
{
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Question { get; set; } = default!;

    [Required]
    [MaxLength(255)]
    public string Answer { get; set; } = default!;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}