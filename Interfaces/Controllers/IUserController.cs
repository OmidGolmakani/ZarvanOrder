using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.Controllers
{
    public interface IUserController
    {
        Task GetPhoneNumberVerification(Model.Dtos.Requests.Users.GetUserRequest request);
        Task GetEmailVerification(Model.Dtos.Requests.Users.GetUserRequest request);
        Task<IActionResult> Signin(Model.Dtos.Requests.Users.LoginRequst requst);
        Task Signout();
    }
}
