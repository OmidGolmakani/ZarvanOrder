using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Entites
{
    public class GoodsGroup : AuditDeleteEntity<int>
    {
        public int FatherId { get; set; }
        public int RefId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public GoodsGroup FatherGoodsGroup { get; set; }
        public ICollection<GoodsGroup> ChildGoodsGroups { get; set; }
    }
}
