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
        public void GetsAsync_WithUnexistingItem_ReturnNotFound()
        {
            ///Arrage
            var userServiceSetup = new Mock<IUserService>();
            userServiceSetup.Setup(srv => srv.GetAsync(It.IsAny<GetUserRequest>())).
                ReturnsAsync((UserResponse)null);
            var controller = new UserController(userServiceSetup.Object);
            ///Act
            var Random dotNetTips.Utility.Standard.Tester.RandomData.GenerateCharacter();
            var result = await controller.Gets(new GetUsersRequest() )

            ///Assert

        }

    }
}
