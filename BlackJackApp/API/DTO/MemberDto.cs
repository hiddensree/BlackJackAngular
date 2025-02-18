using System;
using API.Entities;

namespace API.DTO;

public class MemberDto
{
    public int Id { get; set; }
    public string? PlayerName { get; set; }
    public int PlayerBalance { get; set; }
    public int Age { get; set; }
    public string? PhotoUrl { get; set; }
    public string? GameTag { get; set; }
    public DateTime Created { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public List<PhotoDto>? Photos { get; set; }
}
