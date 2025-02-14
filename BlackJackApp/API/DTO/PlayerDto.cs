using System;

namespace API.DTO;

public class PlayerDto
{
    public required string Playername { get; set; }

    public required string Token { get; set; }
}
