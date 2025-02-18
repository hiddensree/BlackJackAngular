using API.DTO;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class PlayersController(IPlayerRepository playerRepository)
    : BaseApiController
{
    [HttpGet] // api/players
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetPlayers()
    {
        var players = await playerRepository.GetMembersAsync();
        return Ok(players);
    }

    [HttpGet("{playername}")]
    public async Task<ActionResult<MemberDto>> GetPlayer(string playername)
    {
        var player = await playerRepository.GetMemberByPlayernameAsync(playername);
        if (player == null)
            return NotFound();
        return player;
    }
}
