using System.ComponentModel.DataAnnotations;

namespace CliniqueBackend.Dtos;

public class BlogPostDTO
{
    [Required]
    public string Content { get; set; } = default!;
    [Required]
    public string Author { get; set; } = default!;
    [Required]
    public int DepartmentId { get; set; }
}