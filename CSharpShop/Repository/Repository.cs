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
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        protected readonly ShopContext<T> shopContext;
        public Repository()
        {
            shopContext = new ShopContext<T>();
        }
        public void Create(T item)
        {
            if (item != null)
            {
                shopContext.Items.Add(item);
            }
        }
        public IEnumerable<T> GetItems()
        {
            return shopContext.Items;
        }

        public void Update(T item)
        {
            if (item != null)
            {
                shopContext.Entry(item).State = EntityState.Modified;
            }
        }

        public void Delete(T item)
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
