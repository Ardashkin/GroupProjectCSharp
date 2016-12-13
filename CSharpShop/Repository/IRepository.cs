using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T>
    {
        void Create(T item);
        IEnumerable<T> GetItems();
        void Update(T item);
        void Delete(T item);
        void Save();
    }
}
