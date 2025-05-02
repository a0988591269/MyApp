using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories
{
    public class PlayerRepository : BaseRepository<Player>, IPlayerRepository
    {
        /// <summary>
        /// PlayerRepository 是 BaseRepository<Player> 的子類別
        /// BaseRepository 有一個建構子需要 dbContext
        /// 所以在 PlayerRepository 中建構的時候，要把 dbContext 傳給父類別的建構子，用 base(dbContext) 寫法完成。
        /// </summary>
        /// <param name="dbContext"></param>
        public PlayerRepository(_DbContext dbContext) : base(dbContext) { }

        public async Task<List<Player>> GetAllPlayers()
        {
            return await FindAll().OrderBy(player => player.CreatedDate).ToListAsync();
        }
    }
}
