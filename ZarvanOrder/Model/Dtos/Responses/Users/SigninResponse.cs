using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Model.Dtos.Responses.Users
{
    public class SigninResponse : Bases.BaseResponse<long>
    {
        public SignInResult SignIn { get; set; }
        public TokenResponse Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
