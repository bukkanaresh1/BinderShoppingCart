using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using BinderShoppingCartService;
using BinderShoppingCart.Repository;



namespace BinderShoppingCartService.UnitTest.Controllers
{
    public class CustomerControllerTest
    {
        [Fact]
        public void GetProductsByCategory_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<ICustomersRepository>();
            mockRepository.Setup(repo => repo.GetProductsByCategory(It.IsAny<int>()))
                          .Returns(new List<Product>()); // Replace 'Product' with your actual product class

            var controller = new CustomerController(mockRepository.Object, new Mock<ILogger<CustomerController>>().Object);

            // Act
            var result = controller.GetProductsByCategory(categoryID: 1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var products = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Empty(products); // Assuming no products for simplicity
        }

        [Fact]
        public void GetProductsByCategory_ReturnsInternalServerErrorOnException()
        {
            // Arrange
            var mockRepository = new Mock<ICustomersRepository>();
            mockRepository.Setup(repo => repo.GetProductsByCategory(It.IsAny<int>()))
                          .Throws(new Exception("Simulated exception"));

            var mockLogger = new Mock<ILogger<CustomerController>>();
            var controller = new CustomerController(mockRepository.Object, mockLogger.Object);

            // Act
            var result = controller.GetProductsByCategory(categoryID: 1);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            mockLogger.Verify(
                logger => logger.LogError(It.IsAny<string>(), It.IsAny<Exception>()),
                Times.Once
            );
        }
    }
}
