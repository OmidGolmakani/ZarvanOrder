using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.MarketerAccessRegions
{
    public class GetMarketerAccessRegionsRequest : Pages.PageRequest
    {
        public long? MarketerId { get; set; }
        public int? RegionId { get; set; }
    }
}
