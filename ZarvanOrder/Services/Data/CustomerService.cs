using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Model.Dtos.Requests.Customers;
using ZarvanOrder.Model.Dtos.Responses.Customers;
using ZarvanOrder.Model.Entites;
using ZarvanOrder.Repositores;

namespace ZarvanOrder.Services.Data
{
    public class CustomerService : IService<AddCustomerRequest, EditCustomerRequest, GetCustomerRequest, CustomerResponse>
    {
        private readonly Repository<long, Customer> _repository;
        private readonly Mapper _mapper;

        public CustomerService(Repository<long, Customer> repository,
                               AutoMapper.Mapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<CustomerResponse> Add(AddCustomerRequest request)
        {
            var entity = _mapper.Map<AddCustomerRequest, Customer>(request);
            var result = _mapper.Map<CustomerResponse>(_repository.Add(entity));
            return await Task.Run(() => result);
        }

        public Task BatchDelete(IEnumerable<GetCustomerRequest> request)
        {
            throw new NotImplementedException();
        }

        public Task BatchUpdate(IEnumerable<EditCustomerRequest> request)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(GetCustomerRequest request)
        {
            Customer entity = new();
            _mapper.Map<GetCustomerRequest, Customer>(request, entity);
            var result = _mapper.Map<CustomerResponse>(_repository.Delete(entity));
            await Task.Run(() => result);
        }

        public async Task<CustomerResponse> Update(EditCustomerRequest request)
        {
            Customer entity = new();
            _mapper.Map<EditCustomerRequest, Customer>(request, entity);
            var result = _mapper.Map<CustomerResponse>(_repository.Update(entity));
            return await Task.Run(() => result);
        }
    }
}
