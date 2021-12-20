using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Controllers;
using ZarvanOrder.Model.Dtos.Requests.Customers;
using ZarvanOrder.Services.Data;

namespace ZarvanOrder.Controllers
{
    public class CustomerController : BaseController, IController<AddCustomerRequest, EditCustomerRequest, DeleteCustomerRequest>,
                                                      IGetController<GetCustomerRequest, GetCustomersRequest>
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            this._customerService = customerService;
        }
        public async Task<IActionResult> BachDelete(List<DeleteCustomerRequest> request)
        {
            await _customerService.BatchDelete(request);
            return Ok();
        }

        public async Task<IActionResult> Delete(DeleteCustomerRequest request)
        {
            await _customerService.Delete(request);
            return Ok();
        }

        public async Task<IActionResult> Get(GetCustomerRequest request)
        {
            return Ok(await _customerService.GetAsync(request));
        }

        public async Task<IActionResult> Gets(GetCustomersRequest request)
        {
            return Ok(await _customerService.GetsAsync(request));
        }

        public async Task<IActionResult> Post(AddCustomerRequest request)
        {
            var result = await _customerService.Add(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        public async Task<IActionResult> Put(EditCustomerRequest request)
        {
            var result = await _customerService.Update(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
    }
}
