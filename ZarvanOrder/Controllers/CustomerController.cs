using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Controllers;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Model.Dtos.Requests.Customers;

namespace ZarvanOrder.Controllers
{
    public class CustomerController : BaseController, IController<AddCustomerRequest, EditCustomerRequest, DeleteCustomerRequest>,
                                                      IGetController<GetCustomerRequest, GetCustomersRequest>
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }
        [HttpDelete("BatchDelete")]
        public async Task<IActionResult> BachDelete([FromForm] List<DeleteCustomerRequest> request)
        {
            await _customerService.BatchDelete(request);
            return Ok();
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromForm] DeleteCustomerRequest request)
        {
            await _customerService.Delete(request);
            return Ok();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] GetCustomerRequest request)
        {
            return Ok(await _customerService.GetAsync(request));
        }
        [HttpGet("Gets")]
        public async Task<IActionResult> Gets([FromQuery] GetCustomersRequest request)
        {
            return Ok(await _customerService.GetsAsync(request));
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromForm] AddCustomerRequest request)
        {
            var result = await _customerService.Add(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromForm] EditCustomerRequest request)
        {
            var result = await _customerService.Update(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
    }
}
