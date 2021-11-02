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
    public class UserController : ControllerBase, IController<AddUserRequest, EditUserRequest, DeleteUserRequest>,
                                                  IGetController<GetUserRequest, GetUsersRequest>,
                                                  IUserController
    {
        private readonly IUserService _userService;
        private readonly IService<AddUserRequest, EditUserRequest, DeleteUserRequest, UserResponse> _service;
        private readonly IGetService<GetUserRequest, GetUsersRequest, GetUsersRequest> getService;

        public UserController(IUserService userService,
                              IService<AddUserRequest,EditUserRequest, DeleteUserRequest, UserResponse> service,
                              IGetService<GetUserRequest,GetUsersRequest,GetUsersRequest> _getService
                              )
        {
            this._userService = userService;
            this._service = service;
            this.getService = _getService;
        }
        [HttpPost("BachDelete")]
        public async Task<IActionResult> BachDelete(List<DeleteUserRequest> request)
        {
            await _service.BatchDelete(request);
            return Ok();

        }
        [HttpPost("Delete")]
        public Task<IActionResult> Delete(DeleteUserRequest request)
        {
            throw new NotImplementedException();
        }
        [HttpGet("Get/{Id}")]
        public Task<IActionResult> Get(GetUserRequest request)
        {
            throw new NotImplementedException();
        }
        [HttpGet("Gets")]
        public Task<IActionResult> Gets(GetUsersRequest request)
        {
            throw new NotImplementedException();
        }
        [HttpPost("Post")]
        public Task<IActionResult> Post(AddUserRequest request)
        {
            throw new NotImplementedException();
        }
        [HttpPut("Put")]
        public Task<IActionResult> Put(EditUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
