using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZarvanOrder.Interfaces.Controllers;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Model.Dtos.Requests.Users;
using ZarvanOrder.Model.Dtos.Responses.Users;

namespace ZarvanOrder.Controllers
{
    public class UserController : BaseController, IController<AddUserRequest, EditUserRequest, DeleteUserRequest>,
                                                  IGetController<GetUserRequest, GetUsersRequest>,
                                                  IUserController
    {
        private readonly IUserService _userService;
        private readonly IService<AddUserRequest, EditUserRequest, DeleteUserRequest, UserResponse> _service;
        private readonly IGetService<GetUserRequest, GetUsersRequest, GetUsersRequest> _getService;

        public UserController(IUserService userService,
                              IService<AddUserRequest, EditUserRequest, DeleteUserRequest, UserResponse> service,
                              IGetService<GetUserRequest, GetUsersRequest, GetUsersRequest> _getService
                              )
        {
            this._userService = userService;
            this._service = service;
            this._getService = _getService;
        }
        [HttpPost("BachDelete")]
        public async Task<IActionResult> BachDelete([FromForm] List<DeleteUserRequest> request)
        {
            await _service.BatchDelete(request);
            return Ok();

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] DeleteUserRequest request)
        {
            await _service.Delete(request);
            return Ok();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] GetUserRequest request)
        {
            return Ok(await _getService.GetAsync(request));
        }
        [HttpPost("GetEmailVerification")]
        public Task GetEmailVerification(GetUserRequest request)
        {
            throw new NotImplementedException();
        }
        [HttpPost("GetPhoneNumberVerification")]
        public Task GetPhoneNumberVerification(GetUserRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet("Gets")]
        public async Task<IActionResult> Gets(GetUsersRequest request)
        {
            return Ok(await _getService.GetsAsync(request));
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromForm] AddUserRequest request)
        {
            var result = await _service.Add(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);

        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromForm] EditUserRequest request)
        {
            var result = await _service.Update(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
    }
}
