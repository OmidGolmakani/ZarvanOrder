using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Responses.Users;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IUserRepository : IRepository<long,Model.Entites.User>
    {
        Task<Model.Entites.User> GetById(Model.Dtos.Requests.Users.GetUserRequest request, bool includeDeleted = false);
        IQueryable<Model.Entites.User> Get(Model.Dtos.Requests.Users.GetUsersRequest request, bool includeDeleted = false);
        Task<SigninResponse> SigninAsync(Model.Dtos.Requests.Users.LoginRequst requst);
        Task<IList<string>> GetRolesAsync(Model.Dtos.Requests.Users.GetUserRequest request);
        Task SignoutAsync();
        Task<IdentityResult> AddUserToRoleAsync(Model.Dtos.Requests.Users.GetUserRequest request, string Role);
        Task<bool> IsUniqueUserAsync(Model.Dtos.Requests.Users.UniqueUserValidationRequst requst);
        Task<bool> IsUniqueEmailAsync(Model.Dtos.Requests.Users.UniqueEmailValodationRequest requst);
        Task<bool> IsUniquePhoneNumberAsync(Model.Dtos.Requests.Users.UniquePhoneNumber requst);

    }
}
