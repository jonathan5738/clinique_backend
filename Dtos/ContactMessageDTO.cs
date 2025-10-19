using System.ComponentModel.DataAnnotations;

namespace CliniqueBackend.Dtos;

public class ContactMessageDTO
{
     
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; } = default!;


    [MaxLength(50)]
    public string? MiddleName { get; set; } = default!;

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; } = default!;

    [Required]
    public string Title { get; set; } = default!;

    [MaxLength(255)]
    public string Content { get; set; } = default!;

    [Phone]
    [Required]
    public string PhoneNumber { get; set; } = default!;

    [EmailAddress]
    public string? EmailAddress { get; set; }
}