using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.ResponseType
{
    public static class PageExtensions
    {
        public static PageList<TSource> ToPageList<TSource>(this IQueryable<TSource> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var item = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return new PageList<TSource>(item, count, pageNumber, pageSize);
        }
    }
}
