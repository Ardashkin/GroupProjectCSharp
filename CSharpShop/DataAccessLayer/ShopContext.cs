using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainModel;

namespace DataAccessLayer
{
    public class ShopContext<T> : DbContext where T : class
    {
        public DbSet<T> Items { get; set; }
        public ShopContext() : base("LocalConnection") { }
    }
}
