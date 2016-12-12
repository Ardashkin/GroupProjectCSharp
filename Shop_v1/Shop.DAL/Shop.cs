using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Shop.DAL
{
    public class Shop: DbContext  
    {       
        public DbSet<Client> Clients { get; set; }

        public DbSet<ClState> ClStates { get; set; }        

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderState> OrderStates { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; } 

        public DbSet<PrCategory> PrCategories { get; set; } 

        public DbSet<OrderCart> OrderCarts { get; set; }
    }
}
