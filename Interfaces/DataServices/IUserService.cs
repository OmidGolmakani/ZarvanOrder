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
        Task<Model.Dtos.Responses.Pageing.List<Model.Dtos.Responses.Users.User>> GetUsersAsync(Model.Dtos.Responses.Users.User request);
        Task<long> Count(Model.Dtos.Responses.Users.User request);
        Task<Model.Dtos.Responses.Users.User> GetUserAsync(Model.Dtos.Requests.Users.GetUser request);
        Task<Model.Dtos.Responses.Users.User> AddUserAsync(Model.Dtos.Requests.Users.AddUser request);
        Task<bool> IsUniqueUserAsync(Model.Dtos.Requests.Users.UniqueUser request);
        Task<bool> IsUniquePhoneNumberAsync(Model.Dtos.Requests.Users.UniquePhoneNumber request);
        Task<bool> IsUniqueEmailAsync(Model.Dtos.Requests.Users.UniqueEmail request);
        Task<Model.Dtos.Responses.Users.User> EditUserAsync(Model.Dtos.Requests.Users.EditUser request);
        Task<Model.Dtos.Responses.Users.Signin> SignIn(Model.Dtos.Requests.Users.Login request);
        Task<List<IdentityResult>> AddUserToRole(Model.Dtos.Requests.Users.AddUserToRole request);
        Task<List<string>> GetUserRoles(Model.Dtos.Requests.Users.GetUser request);
        Task BatchDeleteUsersAsync(long[] Ids);
        Task SignOut();
        Task<string> PhoneNumberConfirmation(string PhoneNumber);
        Task<IdentityResult> VerifyPhoneNumber(string PhoneNumber, string Token);
    }
}
