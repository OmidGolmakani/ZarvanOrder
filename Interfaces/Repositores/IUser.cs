using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Interfaces.Repositores
{
    internal interface IUserRepository : IRepository<Model.Entites.User>
    {
        Task<Model.Entites.User> GetById(Model.Dtos.Requests.Users.GetUser request, bool includeDeleted = false);
        Task<IQueryable<Model.Entites.User>> Get(Model.Dtos.Requests.Users.GetUsers request, bool includeDeleted = false);
        Task<int> Count(Model.Dtos.Requests.Users.GetUsers request, bool includeDeleted = false);
    }
}
