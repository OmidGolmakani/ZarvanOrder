using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Interfaces.Repositores;
using ZarvanOrder.Model.Dtos.Requests.Customers;
using ZarvanOrder.Model.Dtos.Responses.Customers;
using ZarvanOrder.Model.Dtos.Responses.Pageing;
using ZarvanOrder.Model.Entites;
using ZarvanOrder.Model.Validation;
using ZarvanOrder.Repositores;

namespace ZarvanOrder.Services.Data
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly Mapper _mapper;

        public CustomerService(ICustomerRepository repository,
                               Mapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<CustomerResponse> Add(AddCustomerRequest request)
        {
            var entity = _mapper.Map<AddCustomerRequest, Customer>(request);
            CustomerValidation validator = new(this);
            await validator.ValidateAndThrowAsync(entity);
            var result = _mapper.Map<CustomerResponse>(_repository.Add(entity));
            return result;
        }

        public async Task BatchDelete(IEnumerable<GetCustomerRequest> request)
        {
            IEnumerable<Customer> entites = null;
            _mapper.Map<IEnumerable<GetCustomerRequest>, IEnumerable<Customer>>(request, entites);
            _repository.DeleteBatch(entites);
            await Task.Delay(0);
        }

        public Task BatchDelete(IEnumerable<DeleteCustomerRequest> request)
        {
            throw new NotImplementedException();
        }

        public async Task BatchUpdate(IEnumerable<EditCustomerRequest> request)
        {
            IEnumerable<Customer> entites = null;
            _mapper.Map<IEnumerable<EditCustomerRequest>, IEnumerable<Customer>>(request, entites);
            _repository.UpdateBatch(entites);
            await Task.Delay(0);
        }

        public Task<int> CountAsync(GetCustomersRequest request)
        {
            var Count = await _repository.Get(request).ToListAsync();
            return Count.Count();
        }

        public async Task Delete(DeleteCustomerRequest request)
        {
            Customer entity = new();
            _mapper.Map<DeleteCustomerRequest, Customer>(request, entity);
            var result = _mapper.Map<CustomerResponse>(_repository.Delete(entity));
            await Task.Run(() => result);
        }

        public Task<CustomerResponse> GetAsync(GetCustomerRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ListResponse<CustomerResponse>> GetsAsync(GetCustomersRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUniqueCustomerCode(string Code)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerResponse> Update(EditCustomerRequest request)
        {
            Customer entity = new();
            _mapper.Map<EditCustomerRequest, Customer>(request, entity);
            CustomerValidation validator = new(this);
            await validator.ValidateAndThrowAsync(entity);
            var result = _mapper.Map<CustomerResponse>(_repository.Update(entity));
            return result;
        }
    }
}
