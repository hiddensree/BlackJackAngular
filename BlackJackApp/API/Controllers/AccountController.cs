using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
{
    [HttpPost("register")] // account/register
    public async Task<ActionResult<PlayerDto>> RegisterPlayer(RegisterPlayerDto registerPlayerDto)
    {
        if (await PlayerExists(registerPlayerDto.Playername))
            return BadRequest("Playername is taken");
        using var hmac = new HMACSHA512(); // Garbage collection

        // var player = new BlackJackPlayer
        // {
        //     PlayerName = registerPlayerDto.Playername,
        //     PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerPlayerDto.Password)),
        //     PasswordSalt = hmac.Key,
        // };

        // await context.BlackJackPlayers.AddAsync(player);
        // await context.SaveChangesAsync();

        // return new PlayerDto
        // {
        //     Playername = player.PlayerName,
        //     Token = tokenService.CreateToken(player),
        // };
        return Ok();
    }

    [HttpPost("login")]
    public async Task<ActionResult<PlayerDto>> LoginPlayer(LoginPlayerDto loginPlayerDto)
    {
        var player = await context.BlackJackPlayers.FirstOrDefaultAsync(x =>
            x.PlayerName.ToLower() == loginPlayerDto.Playername.ToLower()
        );

        if (player == null)
            return BadRequest("Invalid playername");

        using var hmac = new HMACSHA512(player.PasswordSalt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginPlayerDto.Password));

        for (int i = 0; i < computedHash.Length; i++)
        {
            if (computedHash[i] != player.PasswordHash[i])
                return BadRequest("Invalid password");
        }
        return new PlayerDto
        {
            Playername = player.PlayerName,
            Token = tokenService.CreateToken(player),
        };
    }

    private async Task<bool> PlayerExists(string playername)
    {
        return await context.BlackJackPlayers.AnyAsync(x =>
            x.PlayerName.ToLower() == playername.ToLower()
        );
    }
}
