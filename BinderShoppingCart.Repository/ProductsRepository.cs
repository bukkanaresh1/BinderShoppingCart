using BinderShoppingCart.Data.Transformation.Objects;
using BinderShoppingCart.Repository.Interfaces;
using BinderShoppingCart.Repository.Models;

namespace BinderShoppingCart.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        public void AddBrand(string brandName, string brandImagePath = "")
        {
            using (var _context = new BinderShoppingCartContext())
            {
                _context.Brands.Add(new Brand()
                {
                    BrandName = brandName,
                    CreatedBy = "Test",
                    CreatedDate = DateTime.Now,
                    BrandImagePath = brandImagePath,
                    IsActive = true,
                    ModifyDate = DateTime.Now
                });
                _context.SaveChanges();
            }
        }

        public void AddCategory(string categoryName, string categoryImagePath = "")
        {
            using (var _context = new BinderShoppingCartContext())
            {
                _context.Categories.Add(new Category()
                {
                    CategoryName = categoryName,
                    CreatedBy = "Test",
                    CreateDate = DateTime.Now,
                    CategoryImagePath = categoryImagePath,
                    IsActive = true,
                    ModifyDate = DateTime.Now
                });
                _context.SaveChanges();
            }
        }

        public void AddProduct(ProductsDTO product)
        {
            using (var _context = new BinderShoppingCartContext())
            {
                _context.Products.Add(new Product()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    BrandId = product.BrandID,
                    CategoryId = product.CategoryID,
                    TotalQty = product.TotalQty,
                    QtyAvailable = product.TotalQty,
                    ProductImagePath = product.ProductImagePath,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = "Test",
                    CreatedDate = DateTime.Now
                });
                _context.SaveChanges();
            }
        }

        public void UpdateBrand(int id, string brandName, string brandImagePath = "")
        {
            using (var _context = new BinderShoppingCartContext())
            {
                var brand = new Brand()
                {
                    Id = id,
                    BrandName = brandName,
                    BrandImagePath = brandImagePath,
                    ModifyDate = DateTime.Now
                };
                _context.Brands.Attach(brand);
                _context.Entry(brand).Property(x => x.BrandName).IsModified = true;
                _context.Entry(brand).Property(x => x.BrandImagePath).IsModified = true;
                _context.Entry(brand).Property(x => x.ModifyDate).IsModified = true;
                _context.SaveChanges();
            }
        }

        public void UpdateCategory(int id, string categoryName, string categoryImagePath = "")
        {
            using (var _context = new BinderShoppingCartContext())
            {
                var category = new Category()
                {
                    Id = id,
                    CategoryName = categoryName,
                    CategoryImagePath = categoryImagePath,
                    ModifyDate = DateTime.Now
                };
                _context.Categories.Attach(category);
                _context.Entry(category).Property(x => x.CategoryName).IsModified = true;
                _context.Entry(category).Property(x => x.CategoryImagePath).IsModified = true;
                _context.Entry(category).Property(x => x.ModifyDate).IsModified = true;
                _context.SaveChanges();
            }
        }

        public void UpdateProduct(ProductsDTO product)
        {
            using (var _context = new BinderShoppingCartContext())
            {
                var _product = new Product()
                {
                    Id = product.ProductID,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    BrandId = product.BrandID,
                    CategoryId = product.CategoryID,
                    TotalQty = product.TotalQty,
                    QtyAvailable = product.TotalQty,
                    ProductImagePath = product.ProductImagePath,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = "Test",
                    CreatedDate = DateTime.Now
                };
                _context.Products.Attach(_product);
                _context.Entry(_product).Property(x => x.Name).IsModified = true;
                _context.Entry(_product).Property(x => x.Description).IsModified = true;
                _context.Entry(_product).Property(x => x.Price).IsModified = true;
                _context.Entry(_product).Property(x => x.BrandId).IsModified = true;
                _context.Entry(_product).Property(x => x.CategoryId).IsModified = true;
                _context.Entry(_product).Property(x => x.TotalQty).IsModified = true;
                _context.Entry(_product).Property(x => x.QtyAvailable).IsModified = true;
                _context.Entry(_product).Property(x => x.ProductImagePath).IsModified = true;
                _context.Entry(_product).Property(x => x.ModifiedDate).IsModified = true;
                _context.Entry(_product).Property(x => x.CreatedBy).IsModified = true;
                _context.Entry(_product).Property(x => x.CreatedDate).IsModified = true;
                _context.SaveChanges();
            }
        }
    }
}