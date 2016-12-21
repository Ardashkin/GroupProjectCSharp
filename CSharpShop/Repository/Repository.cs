using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccessLayer;
using DomainModel;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly ShopContext<TEntity> shopContext;
        public Repository()
        {
            shopContext = new ShopContext<TEntity>();
        }
        public void Create(TEntity item)
        {
            if (item != null)
            {
                shopContext.Items.Add(item);
            }
        }
        public IEnumerable<TEntity> GetItems()
        {
            return shopContext.Items;
        }

        public void Update(TEntity item)
        {
            if (item != null)
            {
                shopContext.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(TEntity item)
        {
            if (item != null)
            {
                shopContext.Items.Remove(item);
            }
        }

        public void Save()
        {
            shopContext.SaveChanges();
        }
    }
}
