using System.ComponentModel.DataAnnotations;

namespace CliniqueBackend.Dtos;

public class DepartmentDTO
{
    [Required]
    [MaxLength(100)]
    [MinLength(4)]
    public string Name { get; set; } = default!;
}