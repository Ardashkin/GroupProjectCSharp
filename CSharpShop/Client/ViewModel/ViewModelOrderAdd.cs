using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Component;
using DomainModel;

namespace Client.ViewModel
{
    public class ViewModelOrderAdd : ViewModelAdd<Order>
    {
        private readonly ServiceReferenceOrder.IShopServiceBaseOf_Order orderService;
        public ViewModelOrderAdd(ServiceReferenceOrder.IShopServiceBaseOf_Order orderService)
        {
            this.orderService = orderService;
        }
        protected override bool AddItemCommandCanExecute(object obj)
        {
            return this.Item.OrderProducts.Count() > 0;
        }
        protected override void AddItemCommandExecute(object obj)
        {
            orderService.Create(Item);
            Messenger.Instance.Send("Adding of new Order complete");
        }
    }
}
