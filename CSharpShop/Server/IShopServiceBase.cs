using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShopServiceBase" in both code and config file together.
    [ServiceContract]
    public interface IShopServiceBase<T>
    {
        [OperationContract]
        void Create(T item);
        [OperationContract]
        IEnumerable<T> GetItems();
        [OperationContract]
        void Update(T item);
        [OperationContract]
        void Delete(T item);
    }
}
