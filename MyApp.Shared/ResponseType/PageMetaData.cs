using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Shared.ResponseType
{
    public class PageMetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        // 上一頁
        public bool HasPrevious => CurrentPage > 1;
        // 下一頁
        public bool HasNext => CurrentPage < TotalPages;
    }
}
