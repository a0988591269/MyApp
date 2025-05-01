using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    /// <summary>
    /// 基底
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll();
        /// <summary>
        /// Func<T, bool>：可執行的 C# 函數，無法轉成 SQL，只能在記憶體中處理資料
        /// Expression<Func<T, bool>>：函數的語法結構表示式，EF Core 可解析成 SQL 查詢語句，在資料庫中查資料
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
