using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class PlayersController(DataContext context) : BaseApiController
{
    [AllowAnonymous]
    [HttpGet] // api/players
    public async Task<ActionResult<IEnumerable<BlackJackPlayer>>> GetPlayers()
    {
        var players = await context.BlackJackPlayers.ToListAsync();
        return Ok(players);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BlackJackPlayer>> GetPlayer(int id)
    {
        var player = await context.BlackJackPlayers.FindAsync(id);
        if (player == null)
            return NotFound();
        return player;
    }
}
