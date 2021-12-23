using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Customers
{
    public class AddCustomerRequest : Bases.AddRequest
    {
        public long RefId { get; set; }
        public long UserId { get; set; }
        public Model.Enums.Customer.CustomerType CustomerType { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string CompanyName { get; set; }
        public decimal Reminded { get; set; }
    }
}
