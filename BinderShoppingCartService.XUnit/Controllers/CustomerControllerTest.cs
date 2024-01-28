using BinderShoppingCart.Data.Transformation.Objects;
using BinderShoppingCart.Repository.Interfaces;
using BinderShoppingCart.Repository.Models;
using BinderShoppingCartService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace BinderShoppingCartService.XUnit.Controllers
{
    public class CustomerControllerTest
    {
        [Fact]
        public void GetProductsByCategory_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<ICustomersRepository>();
            mockRepository.Setup(repo => repo.GetProductsByCategory(It.IsAny<int>()))
                          .Returns(new List<Product>()); 

            var controller = new CustomerController(mockRepository.Object, new Mock<ILogger<CustomerController>>().Object);

            // Act
            var result = controller.GetProductsByCategory(categoryID: 1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var products = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);
            Assert.Empty(products); 
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
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
           
        }

        [Fact]
        public void AddItemToCart_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<ICustomersRepository>();
            var mockLogger = new Mock<ILogger<CustomerController>>();
            var controller = new CustomerController(mockRepository.Object, mockLogger.Object);
            var productCart = new ProductCart
            {
               
            };
            // Act
            var result = controller.AddItemToCart(productCart);
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);          
            Assert.True(okResult.Value.ToString().Contains("Product added successfully"));

            
        }

        [Fact]
        public void AddItemToCart_ReturnsInternalServerErrorOnException()
        {
            // Arrange
            var mockRepository = new Mock<ICustomersRepository>();
            mockRepository.Setup(repo => repo.AddItemToCart(It.IsAny<ProductCart>()))
                          .Throws(new Exception("Simulated exception"));

            var mockLogger = new Mock<ILogger<CustomerController>>();
            var controller = new CustomerController(mockRepository.Object, mockLogger.Object);

            var productCart = new ProductCart
            {
                
            };

            // Act
            var result = controller.AddItemToCart(productCart);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
         
        }

    }
}
