using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DomainModel;

namespace Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShopServiceBase" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ShopServiceBase.svc or ShopServiceBase.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior]
    public sealed class ShopServiceOrder : ShopServiceBase<Order>
    {
    }
}
