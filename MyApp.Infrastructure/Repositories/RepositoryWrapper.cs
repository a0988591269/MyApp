using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly _DbContext _dbContext;
        private IPlayerRepository _player;
        private ICharacterRepository _character;


        public IPlayerRepository Player
        {
            get { return _player ??= new PlayerRepository(_dbContext); }
        }

        public ICharacterRepository Character
        {
            get { return _character ??= new CharacterRepository(_dbContext); }
        }

        public RepositoryWrapper(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> Save()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
