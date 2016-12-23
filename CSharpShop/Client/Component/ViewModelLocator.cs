using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using ServiceContract;
using DomainModel;
using System.ComponentModel;
using Client.ViewModel;

namespace Client.Component
{
    public class ViewModelLocator
    {
        protected static IKernel container;
        static ViewModelLocator()
        {
            ConfigureContainer();
        }

        private static void ConfigureContainer()
        {
            container = new StandardKernel();

            if (!IsInDesignMode)
            {
                container.Bind<IShopServiceBase<BaseModel>>().To<ShopServiceBase<BaseModel>>();
                container.Bind<IShopServiceBase<User>>().To<ShopServiceBase<User>>();
                container.Bind<IShopServiceBase<Order>>().To<ShopServiceBase<Order>>();
                container.Bind<IShopServiceBase<OrderProduct>>().To<ShopServiceBase<OrderProduct>>();
                container.Bind<IShopServiceBase<Product>>().To<ShopServiceBase<Product>>();
                container.Bind<IShopServiceBase<ProductPrice>>().To<ShopServiceBase<ProductPrice>>();
            }
        }

        protected static bool IsInDesignMode
        {
            get
            {
                return DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject());
            }
        }

        public ViewModelOrderAdd ViewModelOrderAdd
        {
            get { return container.Get<ViewModelOrderAdd>(); }
        }
        public ViewModelOrderShow ViewModelOrderShow
        {
            get { return container.Get<ViewModelOrderShow>(); }
        }
        public ViewModelOrderEdit ViewModelOrderEdit
        {
            get { return container.Get<ViewModelOrderEdit>(); }
        }
        public ViewModelUserAdd ViewModelUserAdd
        {
            get { return container.Get<ViewModelUserAdd>(); }
        }
        public ViewModelUserEdit ViewModelUserEdit
        {
            get { return container.Get<ViewModelUserEdit>(); }
        }
        public ViewModelUserShow ViewModelUserShow
        {
            get { return container.Get<ViewModelUserShow>(); }
        }
        public ViewModelProductAdd ViewModelProductAdd
        {
            get { return container.Get<ViewModelProductAdd>(); }
        }
        public ViewModelProductEdit ViewModelProductEdit
        {
            get { return container.Get<ViewModelProductEdit>(); }
        }
        public ViewModelProductShow ViewModelProductShow
        {
            get { return container.Get<ViewModelProductShow>(); }
        }
    }
}
