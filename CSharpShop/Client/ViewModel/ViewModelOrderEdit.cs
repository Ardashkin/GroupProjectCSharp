using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Component;
using DomainModel;

namespace Client.ViewModel
{
    public class ViewModelOrderEdit : ViewModelEdit<Order>
    {
        private readonly ServiceReferenceOrder.IShopServiceBaseOf_Order orderService;
        public ViewModelOrderEdit(ServiceReferenceOrder.IShopServiceBaseOf_Order orderService)
        {
            this.orderService = orderService;
        }
        protected override bool EditItemCommandCanExecute(object obj)
        {
            return this.SelectedItem.OrderProducts.Count() > 0;
        }

        protected override void EditItemCommandExecute(object obj)
        {
            orderService.Update(SelectedItem);
            Messenger.Instance.Send("Order edition complete");
        }
    }
}
