using BinderShoppingCart.Data.Transformation.Objects;
using BinderShoppingCart.Repository.Interfaces;
using BinderShoppingCart.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using CustomerOrder = BinderShoppingCart.Repository.Models.CustomerOrder;
using OrderStatus = BinderShoppingCart.Data.Transformation.Objects.OrderStatus;

namespace BinderShoppingCart.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        public void AddItemToCart(ProductCart productCart)
        {
            using (var _context = new BinderShoppingCartContext())
            {
                _context.CustomerOrders.Add(new CustomerOrder()
                {
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    OrderStatusId = (int) OrderStatus.InCart,
                    Qty = productCart.Qty,
                    UserId = productCart.UserID,
                    ProductId = productCart.ProductID
                });
                _context.SaveChanges();
            }
        }

        public void CancelOrder(int orderID)
        {
            using (var _context = new BinderShoppingCartContext())
            {
                var order = new CustomerOrder()
                {
                    Id = orderID,
                    OrderStatusId = (int)OrderStatus.OrderCanceled
                };
                _context.CustomerOrders.Attach(order);
                _context.Entry(order).Property(x => x.OrderStatusId).IsModified = true;
                _context.SaveChanges();
            }
        }

        public List<Data.Transformation.Objects.CustomerOrder> GetCustomerOrders(int customerID, int pageNumber = 1, int PageSize = 5)
        {
            using (var _context = new BinderShoppingCartContext())
            {
                return _context.CustomerOrders.Where(x => x.UserId == customerID).Skip(pageNumber - 1).Take(PageSize)
                                        .Select(x => new Data.Transformation.Objects.CustomerOrder
                                        {
                                            ProductName = x.Product.Name,
                                            BrandName = x.Product.Brand.BrandName,
                                            CategoryName = x.Product.Category.CategoryName,
                                            Qty = x.Qty,
                                            OrderStatus = (OrderStatus) x.OrderStatus.Id
                                        }).ToList();
            }
        }

        public List<Product> GetProductsByCategory(int categoryID)
        {
            using (var _context = new BinderShoppingCartContext())
            {
                return _context.Products.Where(x => x.CategoryId == categoryID).ToList();
            }
        }

        public void RemoveItemFromCart(int orderId)
        {
            using (var _context = new BinderShoppingCartContext())
            {
                var cartItem = _context.CustomerOrders.Where(x => x.Id == orderId).FirstOrDefault();
                if (cartItem != null)
                {
                    _context.CustomerOrders.Remove(cartItem);
                    _context.SaveChanges();
                }
            }
        }

        public List<ProductSearchResult> SearchProducts(string searchText, int pageNumber = 1, int PageSize = 5, string sortOrder = "desc")
        {
            List<ProductSearchResult> result = new List<ProductSearchResult>();
            using (var _context = new BinderShoppingCartContext())
            {
                if (sortOrder == "desc")
                {
                    result = _context.Products.Where(x => x.Name.Contains(searchText)).OrderByDescending(x => x.Price).Skip(pageNumber - 1).Take(PageSize)
                                        .Select(x => new ProductSearchResult
                                        {
                                            ProductName = x.Name,
                                            BrandName = x.Brand.BrandName,
                                            CategoryName = x.Category.CategoryName,
                                            Price = x.Price
                                        }).ToList();
                   
                }
                else
                {
                    result = _context.Products.Where(x => x.Name.Contains(searchText)).OrderBy(x => x.Price).Skip(pageNumber - 1).Take(PageSize)
                                        .Select(x => new ProductSearchResult
                                        {
                                            ProductName = x.Name,
                                            BrandName = x.Brand.BrandName,
                                            CategoryName = x.Category.CategoryName,
                                            Price = x.Price
                                        }).ToList();
                }

            }
            return result;
        }
    }
}
