using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.Users;
using ZarvanOrder.Model.Dtos.Responses.Users;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Interfaces.DataServices
{
    public interface IUserService : IService<AddUserRequest, EditUserRequest, DeleteUserRequest, UserResponse>,
                                    IGetService<GetUserRequest, GetUsersRequest, UserResponse>
    {
        Task<bool> IsUniqueUserAsync(Model.Dtos.Requests.Users.UniqueUserValidationRequst request);
        Task<bool> IsUniquePhoneNumberAsync(Model.Dtos.Requests.Users.UniquePhoneNumber request);
        Task<bool> IsUniqueEmailAsync(Model.Dtos.Requests.Users.UniqueEmailValodationRequest request);
        Task<SignInResult> SignInAsync(Model.Dtos.Requests.Users.LoginRequst request);
        Task<List<IdentityResult>> AddUserToRole(Model.Dtos.Requests.Users.AddUserToRoleRequest request);
        Task<IList<string>> GetUserRolesAsync(Model.Dtos.Requests.Users.GetUserRequest request);
        Task SignoutAsync();
        Task<string> PhoneNumberConfirmation(string PhoneNumber);
        Task<IdentityResult> VerifyPhoneNumber(string PhoneNumber, string Token);
    }
}
