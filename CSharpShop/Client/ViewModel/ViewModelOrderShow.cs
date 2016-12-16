using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Client.Component;

namespace Client.ViewModel
{
    public class ViewModelOrderShow : ViewModelShow<Order>
    {
        private readonly ServiceReferenceOrder.IShopServiceBaseOf_Order orderService;
        public ViewModelOrderShow(ServiceReferenceOrder.IShopServiceBaseOf_Order orderService)
        {
            this.orderService = orderService;
        }

        public override void GetData()
        {
            Reset();
            foreach (var element in orderService.GetItems())
            {
                obsCollection.Add(element);
            }
        }
        protected override void OpenViewCommandExecute(object obj)
        {
            GetData();
        }
        protected override void OpenedViewCommandExecute(object obj)
        {
            GetData();
        }
        protected override void RemoveItemCommandExecute(object obj)
        {
            if (RemoveItemCommandCanExecute(obj))
            {
                orderService.Delete(SelectedItem);
                GetData();
            }
        }
        protected override void EditItemCommandExecute(object obj)
        {
            Order order = new Order
            {
                Id = Guid.NewGuid(),
                OrderProducts = this.SelectedItem.OrderProducts,
                Status = this.SelectedItem.Status,
                UserId = this.SelectedItem.UserId
            };
            GetData();
        }
    }
}
