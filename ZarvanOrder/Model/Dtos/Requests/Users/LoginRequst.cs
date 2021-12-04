using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Users
{
    public class LoginRequst : Bases.BaseRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [DefaultValue(false)]
        public bool isPersistent { get; set; }
    }
}
