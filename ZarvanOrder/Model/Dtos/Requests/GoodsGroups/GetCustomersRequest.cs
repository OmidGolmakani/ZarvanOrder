using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.GoodsGroups
{
    public class GetGoodsGroupsRequest : Pages.PageRequest
    {
        public int? FatherId { get; set; }
        public int? RefId { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }
    }
}
