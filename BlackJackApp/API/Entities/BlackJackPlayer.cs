namespace API.Entities;

public class BlackJackPlayer
{

    public int Id { get; set; }
    public required string PlayerName { get; set; }
    public required byte[] PasswordHash {get; set;}
    public required byte[] PasswordSalt {get; set;}
    public int PlayerBalance {get; set;}

}