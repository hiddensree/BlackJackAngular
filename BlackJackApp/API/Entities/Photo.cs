using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

[Table("Photos")]
public class Photo
{
    public int Id { get; set; }
    public required string Url { get; set; }
    public bool isMain { get; set; }
    public string? PublicId { get; set; }

    //Navigation Properties
    public int BlackJackPlayerId { get; set; }
    public BlackJackPlayer BlackJackPlayer { get; set; } = null!;
}
