using API.DTO;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class PlayerRepository(DataContext context, IMapper mapper) : IPlayerRepository
{
    public async Task<MemberDto?> GetMemberByPlayernameAsync(string playername)
    {
        return await context
            .BlackJackPlayers.Where(x => x.PlayerName == playername)
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider) // optimized
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await context
            .BlackJackPlayers.ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<BlackJackPlayer?> GetPlayerByIdAsync(int id)
    {
        return await context.BlackJackPlayers.FindAsync(id);
    }

    public async Task<BlackJackPlayer?> GetPlayerByPlayernameAsync(string playername)
    {
        return await context
            .BlackJackPlayers.Include(x => x.Photos)
            .FirstOrDefaultAsync(x => x.PlayerName == playername);
    }

    public async Task<IEnumerable<BlackJackPlayer>> GetPlayersAsync()
    {
        return await context.BlackJackPlayers.Include(x => x.Photos).ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(BlackJackPlayer player)
    {
        context.Entry(player).State = EntityState.Modified;
    }
}
