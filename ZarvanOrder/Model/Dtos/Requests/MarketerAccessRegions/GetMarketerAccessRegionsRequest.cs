using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.MarketerAccessRegions
{
    public class GetMarketerAccessRegionsRequest : Pages.PageRequest
    {
        public long? MarketerId { get; set; }
        public int? RegionId { get; set; }
        [JsonIgnore]
        public override int PageIndex { get => base.PageIndex; set => base.PageIndex = value; }
        [JsonIgnore]
        public override int PageSize { get => base.PageSize; set => base.PageSize = value; }
    }
}
