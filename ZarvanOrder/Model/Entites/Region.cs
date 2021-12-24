using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Entites
{
    public class Region : AuditDeleteEntity<int>
    {
        public int? RegionFatherId { get; set; }
        public int RefId { get; set; }
        public int RegionCode { get; set; }
        public string RegionName { get; set; }
        public byte Level { get; set; }
        public bool Active { get; set; }
        public Region FatherRegion { get; set; }
        public ICollection<Region> ChildRegion { get; set; }
        public ICollection<MarketerAccessRegion> MarketerAccessRegions { get; set; }
    }
}
