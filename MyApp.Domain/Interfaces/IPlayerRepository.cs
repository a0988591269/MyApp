using MyApp.Domain.Entities;

namespace MyApp.Domain.Interfaces
{
    public interface IPlayerRepository : IBaseRepository<Player>
    {
        Task<List<Player>> GetAllPlayers();
        Task<Player?> GetPlayerById(Guid playerId);
        Task<Player?> GetPlayerWithCharacters(Guid playerId);
    }
}
