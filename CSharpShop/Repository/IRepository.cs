using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<TEntity>
    {
        void Create(TEntity item);
        IEnumerable<TEntity> GetItems();
        void Update(TEntity item);
        void Delete(TEntity item);
        void Save();
    }
}
