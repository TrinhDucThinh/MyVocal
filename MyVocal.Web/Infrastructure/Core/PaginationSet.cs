using System.Collections.Generic;
using System.Linq;

namespace MyVocal.Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        public int Page { set; get; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<T> Items { get; set; }

        public int County
        {
            get
            {
                return (Items != null) ? Items.Count() : 0;
            }
        }
    }
}