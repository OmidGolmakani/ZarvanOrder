using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.Customers
{
    public class CustomerResponse : Bases.BaseResponse
    {
        public long Id { get; set; }
        public long RefId { get; set; }
        public long UserId { get; set; }
        public string UserFullName { get; set; }
        public byte CustomerTypeId { get; set; }
        public string CustomerType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string CompanyName { get; set; }
        public decimal Reminded { get; set; }
    }
}
