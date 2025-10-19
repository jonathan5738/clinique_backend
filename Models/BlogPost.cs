using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliniqueBackend.Models;

[Table("blog_posts")]
public class BlogPost
{
    public int Id { get; set; }
    public Department Department { get; set; } = default!;
    public int DepartmentId { get; set; }

    [Required]
    [Column(TypeName = "text")]
    public string Content { get; set; } = default!;

    [Required]
    public string Author { get; set; } = default!;

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}