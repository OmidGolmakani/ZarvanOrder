using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZarvanOrder.Model.Dtos.Requests.Users;
using ZarvanOrder.Model.Dtos.Responses.Users;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IUserRepository : IRepository<long,Model.Entites.User>,
                                       IGetRepository<GetUserRequest, GetUsersRequest,User>
    {
        Task<SigninResponse> SigninAsync(LoginRequst requst);
        Task<IList<string>> GetRolesAsync(GetUserRequest request);
        Task SignoutAsync();
        Task<IdentityResult> AddUserToRoleAsync(GetUserRequest request, string Role);
        Task<bool> IsUniqueUserAsync(UniqueUserValidationRequst requst);
        Task<bool> IsUniqueEmailAsync(UniqueEmailValodationRequest requst);
        Task<bool> IsUniquePhoneNumberAsync(UniquePhoneNumber requst);

    }
}
