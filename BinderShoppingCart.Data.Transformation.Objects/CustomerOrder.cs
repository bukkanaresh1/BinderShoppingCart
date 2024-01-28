using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinderShoppingCart.Data.Transformation.Objects
{
    public class CustomerOrder
    {
        public string ProductName { get; set; }

        public string BrandName { get; set; }

        public string CategoryName { get; set; }

        public int Qty { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
   
}
