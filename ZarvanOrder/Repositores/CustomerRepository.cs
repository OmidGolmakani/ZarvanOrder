using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Data.DbContext;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.Customers;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Repositores
{
    public class CustomerRepository : Repository<long, Customer>, ICustomerRepository
    {
        private readonly DbFactory _dbFactory;
        private readonly IMapper _mapper;
        public CustomerRepository(DbFactory dbFactory, IMapper mapper) : base(dbFactory, mapper)
        {
            this._dbFactory = dbFactory;
            this._mapper = mapper;
        }

        public IQueryable<Customer> Get(GetCustomersRequest request, bool includeDeleted = false)
        {
            return this
                 .List(p => (includeDeleted || !p.IsDeleted) &&
                 (string.IsNullOrEmpty(request.Code) || (!string.IsNullOrEmpty(p.Code)
                 && p.Code.Contains(request.Code))) &&
                 (string.IsNullOrEmpty(request.Name) || (!string.IsNullOrEmpty(p.Name)
                 && p.Name.Contains(request.Name))) &&
                 (string.IsNullOrEmpty(request.Family) || (!string.IsNullOrEmpty(p.Family)
                 && p.Family.Contains(request.Family))) &&
                 (string.IsNullOrEmpty(request.CompanyName) || (!string.IsNullOrEmpty(p.CompanyName)
                 && p.CompanyName.Contains(request.CompanyName))) &&
                 (string.IsNullOrEmpty(request.UserName) || (!string.IsNullOrEmpty(p.UserCustomer.UserName)
                 && p.UserCustomer.UserName.Contains(request.UserName))) &&
                 p.CustomerType == (byte)request.CustomerType
                 ).Skip(request.PageSize * request.PageIndex).Take(request.PageSize);
        }

        public Task<Customer> GetById(GetCustomerRequest request, bool includeDeleted = false)
        {
            return this.DbSet
             .Where(c => c.Id == request.Id && (includeDeleted || !c.IsDeleted))
             .AsNoTracking()
             .FirstOrDefaultAsync();
        }
    }
}
