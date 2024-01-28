using BinderShoppingCart.Data.Transformation.Objects;
using BinderShoppingCart.OAuth._2._0;
using BinderShoppingCartService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinderShoppingCartService.XUnit.Controllers
{
    public class LoginControllerTest
    {
        [Fact]
        public void Login_ReturnsUnauthorizedOnInvalidCredentials()
        {
            // Arrange
            var mockConfiguration = new Mock<IConfiguration>();
            //var mockJwtAuthenticationManager = new Mock<JwtAuthenticationManager>(mockConfiguration.Object);

            var mockLogger = new Mock<ILogger<LoginController>>();

            var controller = new LoginController(mockConfiguration.Object, mockLogger.Object);

            // Act
            var result = controller.Login(emailAddress: "invalid@example.com", password: "invalidPassword");

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedResult>(result);
            Assert.Equal(401, unauthorizedResult.StatusCode);
        }

    }
}
