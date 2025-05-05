using MyApp.Domain.Entities;
using MyApp.Shared.RequestParameters;

namespace MyApp.Domain.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Task<List<Player>> GetPlayers(PlayerParameter parameter);
        Task<Player?> GetPlayerById(Guid playerId);
        Task<Player?> GetPlayerWithCharacters(Guid playerId);
    }
}
