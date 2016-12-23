using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DomainModel;

namespace DataAccessLayer
{
    public class ShopContext<TEntity> : DbContext where TEntity : BaseModel
    {
        public DbSet<TEntity> Items { get; set; }
        public ShopContext() : base("LocalConnection")
        {
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = true;
            this.Database.CreateIfNotExists();
        }
        protected override void Dispose(bool disposing)
        {
            Configuration.LazyLoadingEnabled = false;
            base.Dispose(disposing);
        }
    }
}
