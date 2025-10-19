using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CliniqueBackend.Models;

[Index(nameof(WeekDay), IsUnique = true)]
[Table("days")]
public class Day
{
    public int Id { get; set; }

    [Column(TypeName = "varchar(25)")]
    public string WeekDay { get; set; } = default!;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}