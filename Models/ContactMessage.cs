using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CliniqueBackend.Models;

[Table("contact_messages")]
public class ContactMessage
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string FirstName { get; set; } = default!;


    [Column(TypeName = "varchar(50)")]
    [MaxLength(50)]
    public string? MiddleName { get; set; } = default!;

    [Required]
    [MaxLength(50)]
    [Column(TypeName = "varchar(50)")]
    public string LastName { get; set; } = default!;

    [Required]
    public string Title { get; set; } = default!;

    [Column(TypeName = "varchar(255)")]
    public string Content { get; set; } = default!;

    [Phone]
    [Required]
    public string PhoneNumber { get; set; } = default!;

    [EmailAddress]
    public string? EmailAddress { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedAt { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime UpdatedAt { get; set; }
}