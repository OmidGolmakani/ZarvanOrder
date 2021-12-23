using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Entites
{
    public class MarketerAccessRegion : AuditDeleteEntity<long>
    {
        public long UserId { get; set; }
        public int RegionId { get; set; }
        public User Marketer { get; set; }
        public Region Region { get; set; }
    }
}
