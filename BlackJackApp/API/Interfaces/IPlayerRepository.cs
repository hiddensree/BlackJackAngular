using API.DTO;
using API.Entities;

namespace API.Interfaces;

public interface IPlayerRepository
{
    void Update(BlackJackPlayer player);

    Task<bool> SaveAllAsync();

    Task<IEnumerable<BlackJackPlayer>> GetPlayersAsync();
    Task<IEnumerable<MemberDto>> GetMembersAsync();

    Task<BlackJackPlayer?> GetPlayerByIdAsync(int id);

    Task<BlackJackPlayer?> GetPlayerByPlayernameAsync(string playername);

    Task<MemberDto?> GetMemberByPlayernameAsync(string playername);
}
