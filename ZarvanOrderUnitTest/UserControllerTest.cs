using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;
using ZarvanOrder.Controllers;
using ZarvanOrder.Interfaces.DataServices;
using ZarvanOrder.Model.Dtos.Requests.Users;
using ZarvanOrder.Model.Dtos.Responses.Users;

namespace ZarvanOrderUnitTest
{
    public class UserControllerTest
    {
        public UserControllerTest()
        {
        }
        [Fact]
        public async void GetsAsync_WithUnexistingItem_ReturnOK()
        {
            ///Arrage
            var userServiceSetup = new Mock<IUserService>();
            userServiceSetup.Setup(srv => srv.GetAsync(It.IsAny<GetUserRequest>())).
                ReturnsAsync((UserResponse)null);
            var controller = new UserController(userServiceSetup.Object);
            ///Act
            var result = await controller.Gets(new GetUsersRequest());
            ///Assert
            Assert.IsType<OkObjectResult>(result);
        }

    }
}
