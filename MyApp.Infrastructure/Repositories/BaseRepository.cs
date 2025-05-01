using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Interfaces;
using MyApp.Infrastructure.Data;
using System.Linq.Expressions;

namespace MyApp.Infrastructure.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected _DbContext _dbContext { get; set; }

        protected BaseRepository(_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> FindAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }
}
