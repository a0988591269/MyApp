using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Data;
using MyApp.Shared.RequestParameters;
using System.Data.Common;
using System.Reflection.Metadata;

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
        public PlayerRepository(_DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Player>> GetPlayers(PlayerParameter parameter)
        {
            return await FindAll()
                .OrderBy(player => player.CreatedDate)
                .Skip((parameter.PageNumber - 1) * parameter.PageSize)
                .Take(parameter.PageSize)
                .ToListAsync();
        }

        /// <summary>
        /// 依據 Id 查詢 Player
        /// 原因：FirstOrDefaultAsync() 可能會回傳 null，但你回傳的型別卻是 Player（不可為 null），這樣不安全，所以編譯器會警告你「可能發生 null 錯誤」。
        /// Player? 表示你承認它可以是 null，編譯器就不會再警告。
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Player?> GetPlayerById(Guid playerId)
        {
            return await FindByCondition(player => player.Id == playerId)
                .FirstOrDefaultAsync();
        }

        public async Task<Player?> GetPlayerWithCharacters(Guid playerId)
        {
            return await FindByCondition(player => player.Id == playerId)
                .Include(player => player.Characters)
                .FirstOrDefaultAsync();
        }
    }
}
