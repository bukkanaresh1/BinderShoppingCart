using Microsoft.EntityFrameworkCore;
using BinderShoppingCart.Repository.Models;
using BinderShoppingCart.Data.Transformation.Objects;

namespace BinderShoppingCart.Repository.Interfaces
{
    public interface ICustomersRepository
    {
        List<Product> GetProductsByCategory(int categoryID);

        void AddItemToCart(ProductCart productCart);

        void CancelOrder(int orderID);

        void RemoveItemFromCart(int orderId);

        List<BinderShoppingCart.Data.Transformation.Objects.CustomerOrder> GetCustomerOrders(int customerID, 
                                                                    int pageNumber = 1, int PageSize = 5);

        List<ProductSearchResult> SearchProducts(string searchText, int pageNumber = 1, int PageSize = 5, string sortOrder = "desc");


    }
}