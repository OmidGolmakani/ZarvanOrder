using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.GoodsGroups
{
    public class GoodsGroupResponse : Bases.BaseResponse<int>
    {
        public int? FatherId { get; set; }
        public int RefId { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int? FatherCode { get; set; }
        public string FatherName { get; set; }
    }
}
