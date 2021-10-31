using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.Users
{
    public class Signin
    {
        public long UserId { get; set; }
        public SignInResult SignIn { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
