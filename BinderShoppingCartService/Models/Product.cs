using System;
using System.Collections.Generic;

namespace BinderShoppingCartService.Models
{
    public partial class Product
    {
        public Product()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int TotalQty { get; set; }
        public int QtyAvailable { get; set; }
        public string? ProductImagePath { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
