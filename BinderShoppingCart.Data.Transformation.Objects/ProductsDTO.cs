namespace BinderShoppingCart.Data.Transformation.Objects
{
    public class ProductsDTO
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ProductImagePath { get; set; }

        public decimal Price { get; set; }

        public int BrandID { get; set; }

        public int CategoryID { get; set; }

        public int TotalQty { get; set; }

        public int AvailableQty { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
