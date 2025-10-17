using MyApp.Domain.Entities;
using MyApp.Shared.RequestParameters;
using MyApp.Shared.ResponseType;

namespace MyApp.Domain.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        PageList<Player> GetPlayers(PlayerParameter parameter);
        Task<Player?> GetPlayerById(Guid playerId);
        Task<Player?> GetPlayerWithCharacters(Guid playerId);
    }
}
