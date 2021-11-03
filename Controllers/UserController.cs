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

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpPost("BachDelete")]
        public async Task<IActionResult> BachDelete([FromForm] List<DeleteUserRequest> request)
        {
            await _userService.BatchDelete(request);
            return Ok();

        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromForm] DeleteUserRequest request)
        {
            await _userService.Delete(request);
            return Ok();
        }
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] GetUserRequest request)
        {
            return Ok(await _userService.GetAsync(request));
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
        public async Task<IActionResult> Gets([FromQuery] GetUsersRequest request)
        {
            return Ok(await _userService.GetsAsync(request));
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromForm] AddUserRequest request)
        {
            var result = await _userService.Add(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);

        }
        [HttpPut("Put")]
        public async Task<IActionResult> Put([FromForm] EditUserRequest request)
        {
            var result = await _userService.Update(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }
    }
}
