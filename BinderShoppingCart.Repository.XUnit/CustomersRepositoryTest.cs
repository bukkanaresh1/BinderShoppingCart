using BinderShoppingCart.Data.Transformation.Objects;
using BinderShoppingCart.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderStatus = BinderShoppingCart.Data.Transformation.Objects.OrderStatus;

namespace BinderShoppingCart.Repository.XUnit
{
    public class CustomersRepositoryTest
    {
        [Fact]
        public void AddItemToCart_SavesToDatabase()
        {
            //TODO: Add test cases
            Assert.True(1 == 1);
        }
    }
    
}
