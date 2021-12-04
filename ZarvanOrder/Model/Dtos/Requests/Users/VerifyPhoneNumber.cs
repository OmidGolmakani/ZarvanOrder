using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Requests.Users
{
    public class VerifyPhoneNumber
    {
        public long UserId { get; set; }
        public string VerificationCode { get; set; }
    }
}
