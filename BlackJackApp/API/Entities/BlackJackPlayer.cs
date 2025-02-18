using API.Extensions;

namespace API.Entities;

public class BlackJackPlayer
{
    public int Id { get; set; }
    public required string PlayerName { get; set; }
    public byte[] PasswordHash { get; set; } = [];
    public byte[] PasswordSalt { get; set; } = [];
    public int PlayerBalance { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public required string GameTag { get; set; }
    public DateTime Created { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }

    // Navigation Properties
    public List<Photo> Photos { get; set; } = [];

    // public int GetAge()
    // {
    //     return DateOfBirth.CalculateAge();
    // }
}
