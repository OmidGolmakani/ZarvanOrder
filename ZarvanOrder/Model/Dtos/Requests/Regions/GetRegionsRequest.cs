using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Regions
{
    public class GetRegionsRequest : Pages.PageRequest
    {
        public int? RegionFatherId { get; set; }
        public int? RefId { get; set; }
        public int? RegionCode { get; set; }
        public string RegionName { get; set; }
        public Enums.Region.Level? Level { get; set; }
        public bool? Active { get; set; }
    }
}
