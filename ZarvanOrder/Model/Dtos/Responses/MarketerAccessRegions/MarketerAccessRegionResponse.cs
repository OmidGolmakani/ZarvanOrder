using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.MarketerAccessRegions
{
    public class MarketerAccessRegionResponse : Bases.BaseResponse<long>
    {
        public long MarketerId { get; set; }
        public int RegionId { get; set; }
        public string MarketerFullName { get; set; }
        public string RegionName { get; set; }
    }
}
