using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Interfaces.DataServices
{
    internal interface IUserService 
    {
        Task<Model.Dtos.Responses.Pageing.ListResponse<Model.Dtos.Responses.Users.UserResponse>> GetUsersAsync(Model.Dtos.Responses.Users.UserResponse request);
        Task<long> Count(Model.Dtos.Responses.Users.UserResponse request);
        Task<Model.Dtos.Responses.Users.UserResponse> GetUserAsync(Model.Dtos.Requests.Users.GetUserRequest request);
        Task<Model.Dtos.Responses.Users.UserResponse> AddUserAsync(Model.Dtos.Requests.Users.AddUserRequest request);
        Task<bool> IsUniqueUserAsync(Model.Dtos.Requests.Users.UniqueUserValidationRequst request);
        Task<bool> IsUniquePhoneNumberAsync(Model.Dtos.Requests.Users.UniquePhoneNumber request);
        Task<bool> IsUniqueEmailAsync(Model.Dtos.Requests.Users.UniqueEmailValodationRequest request);
        Task<Model.Dtos.Responses.Users.UserResponse> EditUserAsync(Model.Dtos.Requests.Users.EditUserRequest request);
        Task<Model.Dtos.Responses.Users.SigninResponse> SignIn(Model.Dtos.Requests.Users.LoginRequst request);
        Task<List<IdentityResult>> AddUserToRole(Model.Dtos.Requests.Users.AddUserToRoleRequest request);
        Task<List<string>> GetUserRoles(Model.Dtos.Requests.Users.GetUserRequest request);
        Task BatchDeleteUsersAsync(long[] Ids);
        Task SignOut();
        Task<string> PhoneNumberConfirmation(string PhoneNumber);
        Task<IdentityResult> VerifyPhoneNumber(string PhoneNumber, string Token);
    }
}
