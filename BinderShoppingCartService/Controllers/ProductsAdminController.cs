using BinderShoppingCart.Data.Transformation.Objects;
using BinderShoppingCart.Repository.Interfaces;
using BinderShoppingCartService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BinderShoppingCartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProductsAdminController : ControllerBase
    {
        private IProductsRepository _productsRepository;
        private readonly ILogger<ProductsAdminController> _logger;
        public ProductsAdminController(IProductsRepository productsRepository, ILogger<ProductsAdminController> logger)
        {
            _productsRepository = productsRepository;
            _logger = logger;
        }

        [HttpPost]
        [Route("addbrand")]
        public IActionResult AddBrand(string brandName, string brandImagePath = "")
        {
            try
            {
                _productsRepository.AddBrand(brandName, brandImagePath);
                return Ok(new { Message = "Brand added successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Products Admin controller AddBrand method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }

        }

        [HttpPost]
        [Route("updatebrand")]
        public IActionResult UpdateBrand(int id, string brandName, string brandImagePath = "")
        {
            try
            {
                _productsRepository.UpdateBrand(id, brandName, brandImagePath);
                return Ok(new { Message = "Brand updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Products Admin controller UpdateBrand method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }

        }


        [HttpPost]
        [Route("addcategory")]
        public IActionResult AddCategory(string categoryName, string categoryImagePath = "")
        {

            try
            {
                _productsRepository.AddCategory(categoryName, categoryImagePath);
                return Ok(new { Message = "Catgory added successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Products Admin controller AddCategory method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }

        }

        [HttpPost]
        [Route("updatecategory")]
        public IActionResult UpdateCategory(int id, string categoryName, string categoryImagePath = "")
        {
            try
            {
                _productsRepository.UpdateCategory(id, categoryName, categoryImagePath);
                return Ok(new { Message = "Category updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Products Admin controller UpdateCategory method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }

        }

        [HttpPost]
        [Route("addproduct")]
        public IActionResult AddProduct(ProductsDTO product)
        {
            try
            {
                _productsRepository.AddProduct(product);
                return Ok(new { Message = "Product added successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Products Admin controller AddProduct method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }

        }

        [HttpPost]
        [Route("updateproduct")]
        public IActionResult UpdateProduct(ProductsDTO product)
        {
            try
            {
                _productsRepository.UpdateProduct(product);
                return Ok(new { Message = "Product updated successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Products Admin controller UpdateProduct method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }

        }
    }
}
