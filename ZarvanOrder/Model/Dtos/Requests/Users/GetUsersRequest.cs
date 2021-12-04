using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Users
{
    public class GetUsersRequest : Pages.PageRequest
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNUmber { get; set; }
        public string Email { get; set; }
    }
}
