using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.Controllers
{
    public interface IUserController
    {
        Task GetPhoneNumberVerification(Model.Dtos.Requests.Users.GetUserRequest request);
        Task GetEmailVerification(Model.Dtos.Requests.Users.GetUserRequest request);
    }
}
