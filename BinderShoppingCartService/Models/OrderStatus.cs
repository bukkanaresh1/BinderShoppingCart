using System;
using System.Collections.Generic;

namespace BinderShoppingCartService.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int Id { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
