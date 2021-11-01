using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Users
{
    public class GetUserRequest:Bases.GetRequest
    {
        public long Id { get; set; }
    }
}
