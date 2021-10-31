using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.Pageing
{
    public class List<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int Total { get; set; }
    }
}
