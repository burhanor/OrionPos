using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionPos.Core.PaginationObjects
{
    public class Pagination
    {
        public string SearchKey { get; set; } = string.Empty;
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
