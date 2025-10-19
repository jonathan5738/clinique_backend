using System.ComponentModel.DataAnnotations;

namespace CliniqueBackend.Dtos;

public class DayDTO
{
    [Required]
    [MaxLength(25)]
    [MinLength(4)]
    public string WeekDay { get; set; } = default!;
}