using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Users
{
    public class Login : Bases.Base
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
