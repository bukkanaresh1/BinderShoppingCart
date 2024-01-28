using BinderShoppingCart.Data.Transformation.Objects;
using BinderShoppingCart.Repository.Interfaces;
using BinderShoppingCartService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderStatus = BinderShoppingCart.Data.Transformation.Objects.OrderStatus;

namespace BinderShoppingCartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User,Admin")]
    public class CustomerController : ControllerBase
    {
        private ICustomersRepository _customersRepository;
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ICustomersRepository customersRepository, ILogger<CustomerController> logger)
        {
            _customersRepository = customersRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("getproductsbycategory")]
        public IActionResult GetProductsByCategory(int categoryID)
        {
            try
            {
                var products = _customersRepository.GetProductsByCategory(categoryID);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Customer controller GetProductsByCategory method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }
        }

        [HttpPost]
        [Route("additemtocart")]
        public IActionResult AddItemToCart(ProductCart productCart)
        {
            try
            {
                _customersRepository.AddItemToCart(productCart);
                 return Ok(new { Message = "Product added successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Customer controller AddItemToCart method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }
        }

        [HttpPut]
        [Route("cancelOrder")]
        public IActionResult CancelOrder(int orderID)
        {
            try
            {
                _customersRepository.CancelOrder(orderID);
                return Ok(new { Message = "Order cancelled successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Customer controller CancelOrder method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }
        }

        [HttpDelete]
        [Route("removeitemfromcart")]
        public IActionResult RemoveItemFromCart(int orderId)
        {
            try
            {
                _customersRepository.RemoveItemFromCart(orderId);
                 return Ok(new { Message = "Product not found !!" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Customer controller RemoveItemFromCart method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }
        }

        [HttpGet]
        [Route("getcustomerorders")]
        public IActionResult GetCustomerOrders(int customerID, int pageNumber = 1, int PageSize = 5)
        {
            try
            {
                var customerOrders = _customersRepository.GetCustomerOrders(customerID,pageNumber,PageSize);
                return Ok(customerOrders);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Customer controller GetCustomerOrders method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }
        }

        [HttpGet]
        [Route("searchproducts")]
        public IActionResult SearchProducts(string searchText, int pageNumber = 1, int PageSize = 5, string sortOrder = "desc")
        {
            try
            {
                var customerProducts = _customersRepository.SearchProducts(searchText, pageNumber, PageSize, sortOrder);
                return Ok(customerProducts);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error occured in Customer controller SearchProducts method ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }
        }
    }
}
