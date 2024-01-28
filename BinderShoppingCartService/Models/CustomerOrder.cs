using System;
using System.Collections.Generic;

namespace BinderShoppingCartService.Models
{
    public partial class CustomerOrder
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int OrderStatusId { get; set; }
        public int Qty { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }

        public virtual OrderStatus OrderStatus { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
