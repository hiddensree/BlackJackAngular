using System.ComponentModel.DataAnnotations;

namespace API.DTO;

/// <summary>
/// Here, be careful with naming, define it how we want to query with postman or json files
/// </summary>
public class RegisterPlayerDto
{
    [Required]
    [MaxLength(100)]
    public required string Playername { get; set; }

    [Required]
    public required string Password { get; set; }
}
