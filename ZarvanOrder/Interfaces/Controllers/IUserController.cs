using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.Users;

namespace ZarvanOrder.Interfaces.Controllers
{
    public interface IUserController : IController<AddUserRequest, EditUserRequest, DeleteUserRequest>,
                                       IGetController<GetUserRequest, GetUsersRequest>
    {
        Task GetPhoneNumberVerification(GetUserRequest request);
        Task GetEmailVerification(GetUserRequest request);
        Task<IActionResult> SigninAsync(LoginRequst requst);
        Task SignoutAsync();
    }
}
