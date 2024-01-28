using BinderShoppingCart.Repository.Interfaces;
using BinderShoppingCartService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinderShoppingCartService.XUnit.Controllers
{
    public class ProductsAdminControllerTest
    {
        [Fact]
        public void AddBrand_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<IProductsRepository>();
            var mockLogger = new Mock<ILogger<ProductsAdminController>>();

            var controller = new ProductsAdminController(mockRepository.Object, mockLogger.Object);

            // Act
            var result = controller.AddBrand("TestBrand", "brandImagePath");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True(okResult.Value.ToString().Contains("Brand added successfully"));
        }

        [Fact]
        public void AddBrand_ReturnsInternalServerErrorOnException()
        {
            // Arrange
            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(repo => repo.AddBrand(It.IsAny<string>(), It.IsAny<string>()))
                          .Throws(new Exception("Simulated exception"));

            var mockLogger = new Mock<ILogger<ProductsAdminController>>();
            var controller = new ProductsAdminController(mockRepository.Object, mockLogger.Object);

            // Act
            var result = controller.AddBrand("TestBrand", "brandImagePath");

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
           
        }

        [Fact]
        public void UpdateBrand_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<IProductsRepository>();
            var mockLogger = new Mock<ILogger<ProductsAdminController>>();

            var controller = new ProductsAdminController(mockRepository.Object, mockLogger.Object);

            // Act
            var result = controller.UpdateBrand(id: 1, brandName: "UpdatedBrand", brandImagePath: "updatedImagePath");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.True(okResult.Value.ToString().Contains("Brand updated successfully"));

        }

        [Fact]
        public void UpdateBrand_ReturnsInternalServerErrorOnException()
        {
            // Arrange
            var mockRepository = new Mock<IProductsRepository>();
            mockRepository.Setup(repo => repo.UpdateBrand(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                          .Throws(new Exception("Simulated exception"));

            var mockLogger = new Mock<ILogger<ProductsAdminController>>();
            var controller = new ProductsAdminController(mockRepository.Object, mockLogger.Object);

            // Act
            var result = controller.UpdateBrand(id: 1, brandName: "UpdatedBrand", brandImagePath: "updatedImagePath");

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
          
        }
    }
}
