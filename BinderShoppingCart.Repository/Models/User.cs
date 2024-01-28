using System;
using System.Collections.Generic;

namespace BinderShoppingCart.Repository.Models
{
    public partial class User
    {
        public User()
        {
            CustomerOrders = new HashSet<CustomerOrder>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string? AddresLine1 { get; set; }
        public string? AddresLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; } = null!;
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
}
