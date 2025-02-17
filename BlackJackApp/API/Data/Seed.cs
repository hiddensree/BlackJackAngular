using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Seed
{
    public static async Task SeedUsers(DataContext context)
    {
        if (await context.BlackJackPlayers.AnyAsync())
            return;

        var playerData = await File.ReadAllTextAsync("Data/UserSeedData.json");

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var users = JsonSerializer.Deserialize<List<BlackJackPlayer>>(playerData, options); // new instances here, so no new password hash - reason to remove required from the password

        if (users == null)
            return;
        foreach (var user in users)
        {
            using var hmac = new HMACSHA256();

            user.PlayerName = user.PlayerName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password"));
            user.PasswordSalt = hmac.Key;

            context.BlackJackPlayers.Add(user);
        }

        await context.SaveChangesAsync();
    }
}
