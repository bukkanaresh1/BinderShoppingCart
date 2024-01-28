using BinderShoppingCart.Data.Transformation.Objects;

namespace BinderShoppingCart.Repository.Interfaces
{
    public interface IProductsRepository
    {
      void AddBrand(string brandName, string brandImagePath = "");

      void UpdateBrand(int id, string brandName, string brandImagePath = "");

      void AddCategory(string categoryName, string categoryImagePath = "");

      void UpdateCategory(int id, string categoryName, string categoryImagePath = "");

      void AddProduct(ProductsDTO product);

      void UpdateProduct(ProductsDTO product);
    }
}
