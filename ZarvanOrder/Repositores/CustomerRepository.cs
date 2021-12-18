using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.Customers;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Repositores
{
    public class CustomerRepository : ZarvanOrder.Repositores.Repository<long, Model.Entites.Customer>, ICustomerRepository
    {
        public IQueryable<User> Get(GetCustomerRequest request, bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetById(GetCustomerRequest request, bool includeDeleted = false)
        {
            this.DbSet.FirstOrDefaultAsync(p=> p.)
        }
    }
}
