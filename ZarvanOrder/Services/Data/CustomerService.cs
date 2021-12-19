using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.CustomException;
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

        public async Task BatchDelete(IEnumerable<DeleteCustomerRequest> request)
        {
            IEnumerable<Customer> entites = null;
            _mapper.Map<IEnumerable<DeleteCustomerRequest>, IEnumerable<Customer>>(request, entites);
            _repository.DeleteBatch(entites);
            await Task.Delay(0);
        }

        public async Task BatchUpdate(IEnumerable<EditCustomerRequest> request)
        {
            IEnumerable<Customer> entites = null;
            _mapper.Map<IEnumerable<EditCustomerRequest>, IEnumerable<Customer>>(request, entites);
            _repository.UpdateBatch(entites);
            await Task.Delay(0);
        }

        public async Task<int> CountAsync(GetCustomersRequest request)
        {
            var Count = await _repository.Get(request).ToListAsync();
            return Count.Count();
        }

        public async Task Delete(DeleteCustomerRequest request)
        {
            Customer entity = await _repository.GetById(_mapper.Map<GetCustomerRequest>(request));
            if (entity == null)
                throw new MyException(System.Net.HttpStatusCode.NotFound, Model.Messages.General.CustomerNotFound);
            _mapper.Map<DeleteCustomerRequest, Customer>(request, entity);
            var result = _mapper.Map<CustomerResponse>(_repository.Delete(entity));
            await Task.Run(() => result);
        }

        public async Task<CustomerResponse> GetAsync(GetCustomerRequest request)
        {
            return _mapper.Map<CustomerResponse>(await _repository.GetById(request));
        }

        public async Task<ListResponse<CustomerResponse>> GetsAsync(GetCustomersRequest request)
        {
            var items = _mapper.Map<List<CustomerResponse>>(await _repository.Get(request).ToListAsync());
            return new ListResponse<CustomerResponse>() { Items = items, Total = items.Count() };
        }

        public Task<bool> IsUniqueCustomerCode(string Code)
        {
            _repository.Get(new GetCustomersRequest() { Code = Code })
        }

        public async Task<CustomerResponse> Update(EditCustomerRequest request)
        {
            Customer entity = await _repository.GetById(_mapper.Map<GetCustomerRequest>(request));
            if (entity == null)
                throw new MyException(System.Net.HttpStatusCode.NotFound, Model.Messages.General.CustomerNotFound);
            _mapper.Map<EditCustomerRequest, Customer>(request, entity);
            CustomerValidation validator = new(this);
            await validator.ValidateAndThrowAsync(entity);
            var result = _mapper.Map<CustomerResponse>(_repository.Update(entity));
            return result;
        }
    }
}
