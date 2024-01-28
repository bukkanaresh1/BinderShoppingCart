using System;
using System.Collections.Generic;

namespace BinderShoppingCart.Repository.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateTime { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
