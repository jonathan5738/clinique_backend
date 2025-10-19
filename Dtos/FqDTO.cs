using System.ComponentModel.DataAnnotations;

namespace CliniqueBackend.Dtos;

public class FqDTO
{

    [Required]
    [MaxLength(255)]
    public string Question { get; set; } = default!;

    [Required]
    [MaxLength(255)]
    public string Answer { get; set; } = default!;
}