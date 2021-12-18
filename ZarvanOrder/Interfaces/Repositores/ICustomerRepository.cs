using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.Customers;

namespace ZarvanOrder.Interfaces.Repositores
{
    public interface ICustomerRepository : IRepository<long, Model.Entites.Customer>
    {
        Task<Model.Entites.Customer> GetById(GetCustomerRequest request, bool includeDeleted = false);
        IQueryable<Model.Entites.Customer> Get(GetCustomersRequest request, bool includeDeleted = false);
    }
}
