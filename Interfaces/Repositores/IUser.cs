using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface IUserRepository : IRepository<Model.Entites.User>
    {
        Task<Model.Entites.User> GetById(Model.Dtos.Requests.Users.GetUserRequest request, bool includeDeleted = false);
        Task<IQueryable<Model.Entites.User>> Get(Model.Dtos.Requests.Users.GetUsersRequest request, bool includeDeleted = false);
    }
}
