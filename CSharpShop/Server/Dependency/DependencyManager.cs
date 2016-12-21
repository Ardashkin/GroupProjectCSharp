using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using ServiceContract;
using DomainModel;

namespace Server.Dependency
{
    public class DependencyManager
    {
        private static IUnityContainer container;
        private static object syncRoot = new object();

        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                    lock (syncRoot)
                    {
                        container = GetIocContainer();
                    }
                return container;
            }
        }

        private static IUnityContainer GetIocContainer()
        {
            IUnityContainer container = new UnityContainer();

            ConfigureUnityContainer(container);

            return container;
        }

        private static void ConfigureUnityContainer(IUnityContainer container)
        {
            container.RegisterType<IShopServiceBase<Product>, ShopServiceBase<Product>>();
            container.RegisterType<IShopServiceBase<User>, ShopServiceBase<User>>();
            container.RegisterType<IShopServiceBase<Order>, ShopServiceBase<Order>>();
            container.RegisterType<IShopServiceBase<OrderProduct>, ShopServiceBase<OrderProduct>>();
            container.RegisterType<IShopServiceBase<ProductPrice>, ShopServiceBase<ProductPrice>>();
        }
    }
}