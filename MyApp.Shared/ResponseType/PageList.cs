using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.ResponseType
{
    public class PageList<T> : List<T>
    {
        public PageMetaData MetaData { get; set; }

        public PageList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            MetaData = new PageMetaData()
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            AddRange(items);
        }
    }
}
